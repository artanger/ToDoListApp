using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListApp
{
    public partial class AddNewCategories : Form
    {
        // Поле для хранения новой категории
        private string _newCategory;

        public AddNewCategories()
        {
            InitializeComponent();
        }

        // Метод для получения новой категории
        public string GetNewCategory()
        {
            return _newCategory;
        }

        // Обработчик клика по кнопке btnSaveNewCategories
        private void btnSaveNewCategories_Click_1(object sender, EventArgs e)
        {
            string category = txtNewCategories.Text.Trim();
            if (!string.IsNullOrWhiteSpace(category))
            {
                // Проверка уникальности категории в базе
                using (var db = new LiteDatabase("ToDoData.db"))
                {
                    var categories = db.GetCollection<Category>("categories");
                    if (categories.FindOne(c => c.Name.ToLower() == category.ToLower()) == null)
                    {
                        // Сохранение новой категории в базу
                        var newCategory = new Category { Name = category };
                        categories.Insert(newCategory);
                        _newCategory = category; // Прямое присваивание
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Category already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Category name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик клика по кнопке btnCancel
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

