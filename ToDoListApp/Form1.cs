using LiteDB;

namespace ToDoListApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string task = txtTask.Text.Trim();
            if (!string.IsNullOrWhiteSpace(task))
            {
                if (editingItem != null)
                {
                    int index = lstTasks.Items.IndexOf(editingItem);
                    if (index >= 0)
                    {
                        lstTasks.Items[index] = task;
                        label1.Text = "✅ Task updated.";
                        label1.ForeColor = Color.Green;
                    }
                    editingItem = null;
                }
                else
                {
                    lstTasks.Items.Add(task);
                    label1.Text = "✅ Task added.";
                    label1.ForeColor = Color.Green;
                }

                txtTask.Clear();
                txtTask.Focus();
                lblDate.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            }
            else
            {
                label1.Text = "⚠️ Task cannot be empty.";
                label1.ForeColor = Color.Red;
            }
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {

            try
            {
                using (var db = new LiteDatabase("ToDoData.db"))
                {
                    var collection = db.GetCollection<Item>("tasks");
                    collection.DeleteAll(); // Очистим старые данные перед сохранением

                    foreach (var task in lstTasks.Items)
                    {
                        if (task is Item item)
                        {
                            collection.Insert(item);
                        }
                        else if (task is string description) // если вдруг старый тип
                        {
                            var newItem = new Item
                            {
                                Description = description,
                                CreatedAt = DateTime.Now
                            };
                            collection.Insert(newItem);
                        }
                    }
                }
                label1.Text = "💾 Tasks saved to database.";
                label1.ForeColor = Color.Blue;
            }
            catch (Exception ex) 
            {
                label1.Text = $"💾 Error: {ex.Message}.";
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

                lblDate.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItems.Count > 0)
            {
                // Удалить все выбранные элементы
                var selectedItems = lstTasks.SelectedItems.Cast<object>().ToArray();
                foreach (var item in selectedItems)
                {
                    lstTasks.Items.Remove(item);
                }
                label1.Text = "🗑️ Selected tasks deleted.";
                label1.ForeColor = Color.OrangeRed;
            }
            else if (lstTasks.Items.Count > 0)
            {
                // Удалить все, если ничего не выделено
                lstTasks.Items.Clear();
                label1.Text = "🧹 All tasks cleared.";
                label1.ForeColor = Color.Gray;
            }
            else
            {
                label1.Text = "📭 Nothing to delete.";
                label1.ForeColor = Color.DimGray;
            }
            // Обновление даты
            lblDate.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        }

        private void lstTasks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnDelete.PerformClick();
                e.Handled = true;
            }
        }

        private object editingItem = null;
        private void lstTasks_DoubleClick(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                editingItem = lstTasks.SelectedItem;
                txtTask.Text = editingItem.ToString();
                txtTask.Focus();

                label1.Text = "✏️ Editing task...";
                label1.ForeColor = Color.MediumBlue;
            }
        }


    }
}
