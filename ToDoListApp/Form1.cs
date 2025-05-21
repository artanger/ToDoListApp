using LiteDB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListApp
{
    public partial class Form1 : Form
    {
        private object editingItem = null;
        private readonly string dbPath = "ToDoData.db";
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string apiBaseUrl = "http://localhost:5000/api/tasks/";
        private HttpListener httpListener;
        private bool isServerRunning = false;

        public Form1()
        {
            InitializeComponent();
            httpClient.BaseAddress = new Uri(apiBaseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // Настройка чекбокса
            chkServer.Checked = false; // Сервер изначально выключен
            chkServer.CheckedChanged += ChkServer_CheckedChanged;
        }

        // Класс задачи
        public class Item
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? UpdatedAt { get; set; }

            public override string ToString() => Description;
        }

        // Обработчик изменения состояния чекбокса
        private void ChkServer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkServer.Checked)
            {
                StartHttpListener();
            }
            else
            {
                StopHttpListener();
            }
        }

        // Запуск HTTP-сервера с HttpListener
        private void StartHttpListener()
        {
            if (isServerRunning)
                return;

            httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:5000/api/tasks/");
            try
            {
                httpListener.Start();
                isServerRunning = true;
                Task.Run(() => HandleHttpRequests());
                label1.Text = "🌐 HTTP-сервер запущен на http://localhost:5000/api/tasks/";
                label1.ForeColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {
                isServerRunning = false;
                chkServer.Checked = false; // Сбрасываем чекбокс при ошибке
                label1.Text = $"❌ Ошибка запуска сервера: {ex.Message}";
                label1.ForeColor = Color.Red;
            }
        }

        // Остановка HTTP-сервера
        private void StopHttpListener()
        {
            if (!isServerRunning)
                return;

            try
            {
                httpListener?.Stop();
                httpListener?.Close();
                httpListener = null;
                isServerRunning = false;
                label1.Text = "🛑 HTTP-сервер остановлен. Используется мок-API.";
                label1.ForeColor = Color.Orange;
            }
            catch (Exception ex)
            {
                label1.Text = $"❌ Ошибка остановки сервера: {ex.Message}";
                label1.ForeColor = Color.Red;
            }
        }

        // Обработка HTTP-запросов с HttpListener
        private async Task HandleHttpRequests()
        {
            while (isServerRunning && httpListener.IsListening)
            {
                try
                {
                    var context = await httpListener.GetContextAsync();
                    var request = context.Request;
                    var response = context.Response;

                    using var db = new LiteDatabase(dbPath);
                    var collection = db.GetCollection<Item>("tasks");

                    if (request.HttpMethod == "GET" && request.Url.AbsolutePath == "/api/tasks")
                    {
                        var tasks = collection.FindAll().ToList();
                        var json = System.Text.Json.JsonSerializer.Serialize(tasks);
                        var buffer = Encoding.UTF8.GetBytes(json);
                        response.ContentType = "application/json";
                        response.StatusCode = 200;
                        await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    else if (request.HttpMethod == "POST" && request.Url.AbsolutePath == "/api/tasks")
                    {
                        using var reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding);
                        var body = await reader.ReadToEndAsync();
                        var item = System.Text.Json.JsonSerializer.Deserialize<Item>(body);
                        item.Id = collection.Count() + 1;
                        item.CreatedAt = DateTime.Now;
                        collection.Insert(item);
                        var json = System.Text.Json.JsonSerializer.Serialize(item);
                        var buffer = Encoding.UTF8.GetBytes(json);
                        response.ContentType = "application/json";
                        response.StatusCode = 201;
                        await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    else if (request.HttpMethod == "PUT" && request.Url.AbsolutePath.StartsWith("/api/tasks/"))
                    {
                        var id = int.Parse(request.Url.AbsolutePath.Split('/').Last());
                        using var reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding);
                        var body = await reader.ReadToEndAsync();
                        var item = System.Text.Json.JsonSerializer.Deserialize<Item>(body);
                        var existing = collection.FindById(id);
                        if (existing != null)
                        {
                            existing.Description = item.Description;
                            existing.UpdatedAt = DateTime.Now;
                            collection.Update(existing);
                            response.StatusCode = 200;
                        }
                        else
                        {
                            response.StatusCode = 404;
                        }
                    }
                    else if (request.HttpMethod == "DELETE" && request.Url.AbsolutePath.StartsWith("/api/tasks/"))
                    {
                        var id = int.Parse(request.Url.AbsolutePath.Split('/').Last());
                        if (collection.Delete(id))
                            response.StatusCode = 204;
                        else
                            response.StatusCode = 404;
                    }
                    else
                    {
                        response.StatusCode = 400;
                    }

                    response.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка обработки запроса: {ex.Message}");
                }
            }
        }

        // Мок-API для тестирования (использует LiteDB)
        private async Task<HttpResponseMessage> MockApiRequest(HttpMethod method, string endpoint, Item item = null)
        {
            using var db = new LiteDatabase(dbPath);
            var collection = db.GetCollection<Item>("tasks");
            if (method == HttpMethod.Get && endpoint == "/api/tasks")
            {
                var tasks = collection.FindAll().ToList();
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = JsonContent.Create(tasks)
                };
            }
            else if (method == HttpMethod.Post && endpoint == "/api/tasks")
            {
                item.Id = collection.Count() + 1;
                collection.Insert(item);
                return new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = JsonContent.Create(item)
                };
            }
            else if (method == HttpMethod.Put && endpoint.StartsWith("/api/tasks/"))
            {
                var id = int.Parse(endpoint.Split('/').Last());
                var existing = collection.FindById(id);
                if (existing != null)
                {
                    existing.Description = item.Description;
                    existing.UpdatedAt = DateTime.Now;
                    collection.Update(existing);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            else if (method == HttpMethod.Delete && endpoint.StartsWith("/api/tasks/"))
            {
                var id = int.Parse(endpoint.Split('/').Last());
                return collection.Delete(id)
                    ? new HttpResponseMessage(HttpStatusCode.NoContent)
                    : new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        // POST: Добавить задачу
        private async Task PostTask(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                label1.Text = "⚠️ Задача не может быть пустой.";
                label1.ForeColor = Color.Red;
                return;
            }

            var newItem = new Item { Description = description, CreatedAt = DateTime.Now };
            try
            {
                HttpResponseMessage response = !chkServer.Checked
                    ? await MockApiRequest(HttpMethod.Post, "/api/tasks", newItem)
                    : await httpClient.PostAsJsonAsync("", newItem);

                if (response.IsSuccessStatusCode)
                {
                    var createdItem = !chkServer.Checked ? newItem : await response.Content.ReadFromJsonAsync<Item>();
                    lstTasks.Items.Add(createdItem);
                    label1.Text = "✅ Задача добавлена.";
                    label1.ForeColor = Color.Green;
                }
                else
                {
                    label1.Text = $"❌ Ошибка добавления: {response.StatusCode}";
                    label1.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                label1.Text = $"❌ Ошибка: {ex.Message}";
                label1.ForeColor = Color.Red;
            }

            txtTask.Clear();
            txtTask.Focus();
            lblDate.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        }

        // GET: Получить все задачи
        private async Task GetTasks()
        {
            try
            {
                HttpResponseMessage response = !chkServer.Checked
                    ? await MockApiRequest(HttpMethod.Get, "/api/tasks")
                    : await httpClient.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    var tasks = await response.Content.ReadFromJsonAsync<List<Item>>();
                    lstTasks.Items.Clear();
                    foreach (var task in tasks)
                        lstTasks.Items.Add(task);
                    label1.Text = "📂 Задачи загружены.";
                    label1.ForeColor = Color.DarkCyan;
                }
                else
                {
                    label1.Text = $"❌ Ошибка загрузки: {response.StatusCode}";
                    label1.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                label1.Text = $"❌ Ошибка: {ex.Message}";
                label1.ForeColor = Color.Red;
            }
            lblDate.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        }

        // PUT: Обновить задачу
        private async Task PutTask(object item, string newDescription)
        {
            if (item is not Item taskItem || string.IsNullOrWhiteSpace(newDescription))
            {
                label1.Text = "⚠️ Неверная задача или описание.";
                label1.ForeColor = Color.Red;
                return;
            }

            taskItem.Description = newDescription;
            taskItem.UpdatedAt = DateTime.Now;

            try
            {
                HttpResponseMessage response = !chkServer.Checked
                    ? await MockApiRequest(HttpMethod.Put, $"/api/tasks/{taskItem.Id}", taskItem)
                    : await httpClient.PutAsJsonAsync($"{taskItem.Id}", taskItem);

                if (response.IsSuccessStatusCode)
                {
                    int index = lstTasks.Items.IndexOf(item);
                    if (index >= 0)
                    {
                        lstTasks.Items[index] = taskItem;
                        label1.Text = "✅ Задача обновлена.";
                        label1.ForeColor = Color.Green;
                    }
                }
                else
                {
                    label1.Text = $"❌ Ошибка обновления: {response.StatusCode}";
                    label1.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                label1.Text = $"❌ Ошибка: {ex.Message}";
                label1.ForeColor = Color.Red;
            }

            editingItem = null;
            txtTask.Clear();
            txtTask.Focus();
            lblDate.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        }

        // DELETE: Удалить задачи
        private async Task DeleteTasks()
        {
            if (lstTasks.SelectedItems.Count > 0)
            {
                try
                {
                    bool allSuccessful = true;
                    var selectedItems = lstTasks.SelectedItems.Cast<Item>().ToArray();
                    foreach (var item in selectedItems)
                    {
                        HttpResponseMessage response = !chkServer.Checked
                            ? await MockApiRequest(HttpMethod.Delete, $"/api/tasks/{item.Id}")
                            : await httpClient.DeleteAsync($"{item.Id}");

                        if (response.IsSuccessStatusCode)
                            lstTasks.Items.Remove(item);
                        else
                        {
                            allSuccessful = false;
                            label1.Text = $"❌ Ошибка удаления задачи {item.Id}: {response.StatusCode}";
                            label1.ForeColor = Color.Red;
                        }
                    }
                    if (allSuccessful)
                    {
                        label1.Text = "🗑️ Выбранные задачи удалены.";
                        label1.ForeColor = Color.OrangeRed;
                    }
                }
                catch (Exception ex)
                {
                    label1.Text = $"❌ Ошибка: {ex.Message}";
                    label1.ForeColor = Color.Red;
                }
            }
            else if (lstTasks.Items.Count > 0)
            {
                try
                {
                    bool allSuccessful = true;
                    foreach (Item item in lstTasks.Items)
                    {
                        HttpResponseMessage response = !chkServer.Checked
                            ? await MockApiRequest(HttpMethod.Delete, $"/api/tasks/{item.Id}")
                            : await httpClient.DeleteAsync($"{item.Id}");
                        if (!response.IsSuccessStatusCode)
                            allSuccessful = false;
                    }
                    if (allSuccessful)
                    {
                        lstTasks.Items.Clear();
                        label1.Text = "🧹 Все задачи удалены.";
                        label1.ForeColor = Color.Gray;
                    }
                    else
                    {
                        label1.Text = "❌ Ошибка очистки задач.";
                        label1.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    label1.Text = $"❌ Ошибка: {ex.Message}";
                    label1.ForeColor = Color.Red;
                }
            }
            else
            {
                label1.Text = "📭 Нечего удалять.";
                label1.ForeColor = Color.DimGray;
            }
            lblDate.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        }

        // Обработчики событий
        private async void btnAdd_Click_1(object sender, EventArgs e)
        {
            string task = txtTask.Text.Trim();
            if (editingItem != null)
                await PutTask(editingItem, task);
            else
                await PostTask(task);
        }

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            label1.Text = "💾 Операции сохраняются автоматически.";
            label1.ForeColor = Color.Blue;
        }

        private async void btnLoad_Click_1(object sender, EventArgs e)
        {
            await GetTasks();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await DeleteTasks();
        }

        private void lstTasks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnDelete.PerformClick();
                e.Handled = true;
            }
        }

        private void lstTasks_DoubleClick(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                editingItem = lstTasks.SelectedItem;
                txtTask.Text = editingItem.ToString();
                txtTask.Focus();
                label1.Text = "✏️ Редактирование задачи...";
                label1.ForeColor = Color.MediumBlue;
            }
        }

        // Остановка сервера при закрытии формы
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopHttpListener();
            base.OnFormClosing(e);
        }
    }
}
