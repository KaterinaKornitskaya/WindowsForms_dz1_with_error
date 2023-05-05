using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    // второй вариант задания "Угадай число" - пользователь должен загадать число компьютера

    // не работает, выдает ошибку при нажатии кнопки да.
    // мне кажется, ошибка происходит, когда я очищаю поле текстбокса и ввожу новое значение
    // может сможете понять, в чем проблема
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Угадаю число...");
        }

        private void button1_Click(object sender, EventArgs e)  // кнопка "Проверить" для нажатия пользователем
                                                                // после ввода числа в ТекстБокс
        {
            Random rnd = new Random();
            int tries = 1;  // счетчик для попіток
            DialogResult result = new DialogResult();
            int computer_num;  // число, которое загадал компьютер
            computer_num = 5;  // здесь должен быть рандом, пока указала 5 для удобства
            do  // цикл 
            {
               if (Convert.ToInt32(textBox1.Text) == computer_num)  // если пользователь угалал число
               {
                   result = MessageBox.Show($"Колличество попыток {tries}", "Угадал", 
                       MessageBoxButtons.OK, MessageBoxIcon.Information);  // вывод информации с кол-вом попыток
                   result = MessageBox.Show($"Хотите продолжить?","Выход", 
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);  // вывод с запросом "Хотите продолжить?"
                   
                   if (result == DialogResult.Yes)  // если да - юзер хочет продолжить
                   {
                       textBox1.Clear();  // очищаем текстБокс
                       Convert.ToInt32(textBox1.Text);  // заново считываем нвоое число
                   }
               }

                if (Convert.ToInt32(textBox1.Text) > computer_num)  // если число юзера больше, чем загаданное уомпютером
                {
                    //textBox1.Clear();
                    result = MessageBox.Show($"Нет, меньше. Попробовать еще?",
                  "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);  // вывод сообщения, вывод "Продолжить?"
                     
                    if (result == DialogResult.Yes)  // если да, продолжить
                    {
                        textBox1.Clear();  // очищаем текстБокс
                        Convert.ToInt32(textBox1.Text);  // заново считываем нвоое число
                    }
                }
                else if (Convert.ToInt32(textBox1.Text) < computer_num)  // если число юзера меньше, чем загаданное уомпютером
                {
                    result = MessageBox.Show($"Нет, больше. Попробовать еще?",
                  "Выход", MessageBoxButtons.YesNo,MessageBoxIcon.Question);  // вывод сообщения, вывод "Продолжить?"
                    if (result == DialogResult.Yes)  // если да, продолжить
                    {
                        textBox1.Clear();  // очищаем текстБокс
                        Convert.ToInt32(textBox1.Text);  // заново считываем нвоое число
                    }
                }

                if (result == DialogResult.No)  // если выбрано Нет
                {
                    this.Close();  // закрыть приложение
                }               
                tries++;  // плюсуем попыткм
            } while (result == DialogResult.Yes) ;          
        }
    }
}
