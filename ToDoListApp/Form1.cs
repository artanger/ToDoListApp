using LiteDB;
using System.Text.RegularExpressions;

namespace ToDoListApp
{
    public partial class Form1 : Form
    {
        private CalendarControl _calendarControl;
        private object editingItem = null;

        public Form1()
        {
            InitializeComponent();
            _calendarControl = new CalendarControl(calendarPanel, monthLabel, prevButton, nextButton);
            _calendarControl.DateSelected += CalendarControl_DateSelected;
        }

        private void CalendarControl_DateSelected(object sender, DateTime selectedDate)
        {
            lblDate.Text = selectedDate.ToString("dd.MM.yyyy");
        }

        private void btnSaveTask_Click(object sender, EventArgs e)
        {
            string task = txtTask.Text.Trim();
            if (!string.IsNullOrWhiteSpace(task))
            {
                // Парсим дату из lblDate
                DateTime taskDate;
                if (!DateTime.TryParseExact(lblDate.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out taskDate) || lblDate.Text == "Date")
                {
                    taskDate = DateTime.Now; // Если дата не выбрана или невалидна, используем текущую
                }

                // Создаём или обновляем задачу
                Item newItem = new Item
                {
                    Description = task,
                    CreatedAt = DateTime.Now,
                    TaskDate = taskDate
                };

                if (editingItem != null)
                {
                    int index = lstTasks.Items.IndexOf(editingItem);
                    if (index >= 0 && editingItem is Item existingItem)
                    {
                        newItem.Id = existingItem.Id; // Сохраняем Id для обновления
                        lstTasks.Items[index] = newItem;
                        label1.Text = "✅ Task updated.";
                        label1.ForeColor = Color.Green;
                    }
                    editingItem = null;
                }
                else
                {
                    lstTasks.Items.Add(newItem);
                    label1.Text = "✅ Task added.";
                    label1.ForeColor = Color.Green;
                }

                // Сохранение в базу
                try
                {
                    using (var db = new LiteDatabase("ToDoData.db"))
                    {
                        var collection = db.GetCollection<Item>("tasks");

                        if (newItem.Id > 0)
                        {
                            // Обновляем существующую запись
                            collection.Update(newItem);
                        }
                        else
                        {
                            // Добавляем новую запись
                            collection.Insert(newItem);
                        }
                    }
                    label1.Text = "💾 Task saved to database.";
                    label1.ForeColor = Color.Blue;
                }
                catch (Exception ex)
                {
                    label1.Text = $"💾 Error: {ex.Message}.";
                    label1.ForeColor = Color.Red;
                    return;
                }

                txtTask.Clear();
                txtTask.Focus();
                // Не обновляем lblDate.Text, чтобы сохранить выбранную дату
            }
            else
            {
                label1.Text = "⚠️ Task cannot be empty.";
                label1.ForeColor = Color.Red;
            }
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase("ToDoData.db"))
            {
                var collection = db.GetCollection<Item>("tasks");
                var tasks = collection.FindAll().ToList();

                lstTasks.Items.Clear();
                foreach (var task in tasks)
                {
                    lstTasks.Items.Add(task);
                }
                label1.Text = "📂 Tasks loaded from database.";
                label1.ForeColor = Color.DarkCyan;

                lblDate.Text = "Date"; // Сбрасываем lblDate при загрузке
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItems.Count > 0)
            {
                var selectedItems = lstTasks.SelectedItems.Cast<object>().ToArray();
                try
                {
                    using (var db = new LiteDatabase("ToDoData.db"))
                    {
                        var collection = db.GetCollection<Item>("tasks");
                        foreach (var item in selectedItems)
                        {
                            if (item is Item taskItem)
                            {
                                collection.Delete(taskItem.Id);
                            }
                            lstTasks.Items.Remove(item);
                        }
                    }
                    label1.Text = "🗑️ Selected tasks deleted.";
                    label1.ForeColor = Color.OrangeRed;
                }
                catch (Exception ex)
                {
                    label1.Text = $"🗑️ Error: {ex.Message}.";
                    label1.ForeColor = Color.Red;
                }
            }
            else if (lstTasks.Items.Count > 0)
            {
                try
                {
                    using (var db = new LiteDatabase("ToDoData.db"))
                    {
                        var collection = db.GetCollection<Item>("tasks");
                        collection.DeleteAll();
                        lstTasks.Items.Clear();
                    }
                    label1.Text = "🧹 All tasks cleared.";
                    label1.ForeColor = Color.Gray;
                }
                catch (Exception ex)
                {
                    label1.Text = $"🧹 Error: {ex.Message}.";
                    label1.ForeColor = Color.Red;
                }
            }
            else
            {
                label1.Text = "📭 Nothing to delete.";
                label1.ForeColor = Color.DimGray;
            }
            lblDate.Text = "Date"; // Сбрасываем lblDate после удаления
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
                if (editingItem is Item item)
                {
                    txtTask.Text = item.Description;
                    lblDate.Text = item.TaskDate.ToString("dd.MM.yyyy");
                }
                else
                {
                    txtTask.Text = editingItem.ToString();
                    lblDate.Text = "Date";
                }
                txtTask.Focus();

                label1.Text = "✏️ Editing task...";
                label1.ForeColor = Color.MediumBlue;
            }
        }

    }
}
