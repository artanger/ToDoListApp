using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public class CalendarControl
    {
        private readonly Panel _calendarPanel;
        private readonly Label _monthLabel;
        private readonly Button _prevButton;
        private readonly Button _nextButton;
        private DateTime _currentDate = DateTime.Today;
        private Button[] _dayButtons;
        private Button _selectedButton;

        public event EventHandler<DateTime> DateSelected;

        public CalendarControl(Panel calendarPanel, Label monthLabel, Button prevButton, Button nextButton)
        {
            _calendarPanel = calendarPanel;
            _monthLabel = monthLabel;
            _prevButton = prevButton;
            _nextButton = nextButton;

            _dayButtons = new Button[42];
            CreateDayButtons();

            _prevButton.Click += PrevButton_Click;
            _nextButton.Click += NextButton_Click;

            LoadCalendar();
        }

        private void CreateDayButtons()
        {
            int tileSize = 40;
            int startX = 0;
            int startY = 0;
            int index = 0;

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Button dayButton = new Button
                    {
                        Width = tileSize,
                        Height = tileSize,
                        Location = new Point(startX + col * 45, startY + row * 45),
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Segoe UI", 10),
                        Visible = false
                    };
                    dayButton.Click += DayButton_Click;
                    _dayButtons[index] = dayButton;
                    _calendarPanel.Controls.Add(dayButton);
                    index++;
                }
            }
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int index = Array.IndexOf(_dayButtons, clickedButton);
            if (index < 0) return;

            DateTime firstDayOfMonth = new DateTime(_currentDate.Year, _currentDate.Month, 1);
            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
            startDayOfWeek = (startDayOfWeek == 0) ? 6 : startDayOfWeek - 1;
            int daysInMonth = DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);

            DateTime selectedDate;
            if (index < startDayOfWeek)
            {
                DateTime prevMonth = _currentDate.AddMonths(-1);
                int daysInPrevMonth = DateTime.DaysInMonth(prevMonth.Year, prevMonth.Month);
                int day = daysInPrevMonth - startDayOfWeek + index + 1;
                selectedDate = new DateTime(prevMonth.Year, prevMonth.Month, day);
            }
            else if (index < startDayOfWeek + daysInMonth)
            {
                int day = index - startDayOfWeek + 1;
                selectedDate = new DateTime(_currentDate.Year, _currentDate.Month, day);
            }
            else
            {
                int day = index - startDayOfWeek - daysInMonth + 1;
                DateTime nextMonth = _currentDate.AddMonths(1);
                selectedDate = new DateTime(nextMonth.Year, nextMonth.Month, day);
            }

            if (_selectedButton != null && _selectedButton != clickedButton)
            {
                ResetButtonStyle(_selectedButton);
            }
            _selectedButton = clickedButton;
            if (selectedDate.Date != DateTime.Today.Date)
            {
                clickedButton.BackColor = Color.FromArgb(100, 181, 246);
                clickedButton.ForeColor = Color.Black;
            }

            DateSelected?.Invoke(this, selectedDate);
        }

        private void ResetButtonStyle(Button button)
        {
            int index = Array.IndexOf(_dayButtons, button);
            DateTime firstDayOfMonth = new DateTime(_currentDate.Year, _currentDate.Month, 1);
            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
            startDayOfWeek = (startDayOfWeek == 0) ? 6 : startDayOfWeek - 1;
            int daysInMonth = DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);

            if (index < startDayOfWeek || index >= startDayOfWeek + daysInMonth)
            {
                button.BackColor = SystemColors.Control;
                button.ForeColor = Color.Gray;
            }
            else
            {
                int day = index - startDayOfWeek + 1;
                if (_currentDate.Year == DateTime.Today.Year &&
                    _currentDate.Month == DateTime.Today.Month &&
                    day == DateTime.Today.Day)
                {
                    button.BackColor = Color.FromArgb(0, 120, 215);
                    button.ForeColor = Color.White;
                }
                else
                {
                    button.BackColor = SystemColors.Control;
                    button.ForeColor = Color.Black;
                }
            }
        }

        private void LoadCalendar()
        {
            _monthLabel.Text = _currentDate.ToString("MMMM yyyy");

            foreach (Button button in _dayButtons)
            {
                button.Text = "";
                button.Visible = false;
                button.BackColor = SystemColors.Control;
                button.ForeColor = Color.Black;
            }

            DateTime firstDayOfMonth = new DateTime(_currentDate.Year, _currentDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);
            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

            startDayOfWeek = (startDayOfWeek == 0) ? 6 : startDayOfWeek - 1;

            DateTime prevMonth = _currentDate.AddMonths(-1);
            int daysInPrevMonth = DateTime.DaysInMonth(prevMonth.Year, prevMonth.Month);
            int prevMonthStartDay = daysInPrevMonth - startDayOfWeek + 1;

            for (int i = 0; i < startDayOfWeek; i++)
            {
                _dayButtons[i].Text = prevMonthStartDay.ToString();
                _dayButtons[i].Visible = true;
                _dayButtons[i].ForeColor = Color.Gray;
                prevMonthStartDay++;
            }

            int currentDay = 1;
            for (int i = startDayOfWeek; i < startDayOfWeek + daysInMonth && i < _dayButtons.Length; i++)
            {
                _dayButtons[i].Text = currentDay.ToString();
                _dayButtons[i].Visible = true;
                _dayButtons[i].ForeColor = Color.Black;

                if (_currentDate.Year == DateTime.Today.Year &&
                    _currentDate.Month == DateTime.Today.Month &&
                    currentDay == DateTime.Today.Day)
                {
                    _dayButtons[i].BackColor = Color.FromArgb(0, 120, 215);
                    _dayButtons[i].ForeColor = Color.White;
                }
                currentDay++;
            }

            int nextMonthDay = 1;
            for (int i = startDayOfWeek + daysInMonth; i < _dayButtons.Length; i++)
            {
                _dayButtons[i].Text = nextMonthDay.ToString();
                _dayButtons[i].Visible = true;
                _dayButtons[i].ForeColor = Color.Gray;
                nextMonthDay++;
            }

            if (_selectedButton != null)
            {
                int selectedIndex = Array.IndexOf(_dayButtons, _selectedButton);
                if (selectedIndex >= 0 && _selectedButton.Visible)
                {
                    if (_dayButtons[selectedIndex].BackColor != Color.FromArgb(0, 120, 215))
                    {
                        _dayButtons[selectedIndex].BackColor = Color.FromArgb(100, 181, 246);
                        _dayButtons[selectedIndex].ForeColor = Color.Black;
                    }
                }
                else
                {
                    _selectedButton = null;
                }
            }

            _prevButton.Enabled = _currentDate.Year > 1 || _currentDate.Month > 1;
            _nextButton.Enabled = _currentDate.Year < 9999 || _currentDate.Month < 12;
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            if (_currentDate.Month == 1)
            {
                if (_currentDate.Year > 1)
                {
                    _currentDate = _currentDate.AddYears(-1);
                    _currentDate = new DateTime(_currentDate.Year, 12, 1);
                }
            }
            else
            {
                _currentDate = _currentDate.AddMonths(-1);
            }
            LoadCalendar();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (_currentDate.Month == 12)
            {
                if (_currentDate.Year < 9999)
                {
                    _currentDate = _currentDate.AddYears(1);
                    _currentDate = new DateTime(_currentDate.Year, 1, 1);
                }
            }
            else
            {
                _currentDate = _currentDate.AddMonths(1);
            }
            LoadCalendar();
        }
    }
}
