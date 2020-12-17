using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_laba_OOP
{
    public partial class laba6 : Form
    {
        public laba6()
        {
            InitializeComponent();
            
        }

        class Figure
        {
            public Color color = Color.Navy;
            public Figure() {   }
        }
        class Circle: Figure
        {
            public int x, y;
            public int rad = 30; // Радиус круга
            //public bool is_drawed = true; // Нарисован ли круг на полотне
            public Circle(int x, int y)
            {
                this.x = x - rad;
                this.y = y - rad;
            }

            ~Circle() { }
        }

        class Line: Figure
        {
            public int x, y, x2, y2;
            public int lenght = 60;
            public Line(int x, int y)
            {
                this.x = x - lenght;
                this.y = y;
                this.x2 = x + lenght;
                this.y2 = y;
            }
        }

        class Square: Figure
        {
            public int x, y, width, height;
            public int size = 60;
            public Square(int x, int y)
            {
                this.x = x - size/2;
                this.y = y - size/2;
                this.width = size;
                this.height = size;
            }
        }

        int p = 0; // Нажат ли был ранее Ctrl
        static int k = 10; // Кол-во ячеек в хранилище
        Storage storag = new Storage(k); // Создаем объект хранилища
        static int index = 0; // Кол-во нарисованных кругов
        int indexin = 0; // Индекс, в какое место был помещён круг
        int figure_now = 1;

        class Storage
        {
            public Figure[] objects;

            public Storage(int count)
            {   // Конструктор по умолчанию 
                // Выделяем count мест в хранилище
                objects = new Figure[count];
                for (int i = 0; i < count; ++i)
                    objects[i] = null;
            }
            public void initialisat(int count)
            {   // Выделяем count мест в хранилище
                objects = new Figure[count];
                for (int i = 0; i < count; ++i)
                    objects[i] = null;
            }
            public void add_object(int ind, ref Figure object1, int count, ref int indexin)
            {   // Добавляет ячейку в хранилище
                // Если ячейка занята ищем свободное место
                while (objects[ind] != null)
                {
                    ind = (ind + 1) % count;
                }
                objects[ind] = object1;
                indexin = ind;
            }

            public void delete_object(int ind)
            {   // Удаляет объект из хранилища
                objects[ind] = null;
                index--;
            }

            public bool check_empty(int index)
            {   // Проверяет занято ли место хранилище
                if (objects[index] == null)
                    return true;
                else return false;
            }

            public int occupied(int size)
            { // Определяет кол-во занятых мест в хранилище
                int count_occupied = 0;
                for (int i = 0; i < size; ++i)
                    if (!check_empty(i))
                        ++count_occupied;
                return count_occupied;
            }

            public void doubleSize(ref int size)
            {   // Функция для увеличения кол-ва элементов в хранилище в 2 раза 
                Storage storage1 = new Storage(size * 2);
                for (int i = 0; i < size; ++i)
                    storage1.objects[i] = objects[i];
                for (int i = size; i < (size * 2) - 1; ++i)
                {
                    storage1.objects[i] = null;
                }
                size = size * 2;
                initialisat(size);
                for (int i = 0; i < size; ++i)
                    objects[i] = storage1.objects[i];
            }

            ~Storage() { }
        };

        private void panel_drawing_MouseClick(object sender, MouseEventArgs e)
        {
            Figure figure = new Figure();
            switch (figure_now)
            {
                case 0:
                    return;
                case 1:
                    figure = new Circle(e.X, e.Y);
                    break;
                case 2:
                    figure = new Line(e.X, e.Y);
                    break;
                case 3:
                    figure = new Square(e.X, e.Y);
                    break;
            }           
            if (index == k)
                storag.doubleSize(ref k);
            //Проверка на наличие фигуры на данных координатах
            int c = check_figure(ref storag, k, e.X, e.Y);
            if (c != -1)
            {   // Если на этом месте уже нарисован круг
                if (Control.ModifierKeys == Keys.Control)
                {   // Если нажат ctrl, то выделяем несколько объектов
                    if (p == 0)
                    {
                        paint_figure(Color.Navy, 4, ref storag, indexin);
                        p = 1;
                    }
                    // Вызываем функцию отрисовки круга   
                    paint_figure(Color.Red, 4, ref storag, c);
                }
                else
                {   // Иначе выделяем только один объект
                    // Снимаем выделение у всех объектов хранилища
                    remove_selection_circle(ref storag);
                    // Вызываем функцию отрисовки круга
                    paint_figure(Color.Red, 4, ref storag, c);
                }
                return;
            }
            // Добавляем круг в хранилище   
            storag.add_object(index, ref figure, k, ref indexin);
            // Снимаем выделение у всех объектов хранилища
            remove_selection_circle(ref storag);
            // Вызываем функцию отрисовки круга
            paint_figure(Color.Red, 4, ref storag, indexin);
            ++index;
            p = 0;

        }

        private void remove_selection_circle(ref Storage stg)
        {   // Снимает выделение у всех элементов хранилища
            for (int i = 0; i < k; ++i)
            {
                if (!storag.check_empty(i))
                {   // Вызываем функцию отрисовки круга
                    paint_figure(Color.Navy, 4, ref storag, i);
                }
            }
        }

        private void remove_selected_circle(ref Storage stg)
        {   // Удаляет выделенные элементы из хранилища
            for (int i = 0; i < k; ++i)
            {
                if (!storag.check_empty(i))
                {
                    if (storag.objects[i].color == Color.Red)
                    {
                        storag.delete_object(i);
                    }
                }
            }
        }
        private void paint_figure(Color name, int size, ref Storage stg, int index)
        {   // Рисует фигуру на панели          
            // Объявляем объект - карандаш, которым будем рисовать контур
            Pen pen = new Pen(name, size);
            if (!storag.check_empty(index))
            {
                if (storag.objects[index] as Circle != null)
                {   // Если в хранилище круг
                    Circle circle = storag.objects[index] as Circle;
                    panel_drawing.CreateGraphics().DrawEllipse(
                    pen, circle.x, circle.y, circle.rad * 2, circle.rad * 2);
                }
                else 
                {
                    if (storag.objects[index] as Line != null)
                    {   // Если в хранилище отрезок
                        Line line = storag.objects[index] as Line;   
                        panel_drawing.CreateGraphics().DrawLine(pen, line.x,
                                                    line.y, line.x2, line.y2);
                    }
                    else
                    {
                        if (storag.objects[index] as Square != null)
                        {   // Если в хранилище квадрат
                            Square square = storag.objects[index] as Square;
                            panel_drawing.CreateGraphics().DrawRectangle(pen,
                                square.x, square.y, square.width,
                                square.height);
                        }
                    }
                }
                stg.objects[index].color = name;
            }
        }
        private int check_figure(ref Storage stg, int size, int x, int y)
        {   // Проверяет есть ли уже фигура с такими же координатами в хранилище
            if (stg.occupied(size) != 0)
            {
                for (int i = 0; i < size; ++i)
                {
                    if (!stg.check_empty(i))
                    {   // Если под i индексом в хранилище есть объект
                        if (storag.objects[i] as Circle != null)
                        {   // Если в хранилище круг
                            Circle circle = storag.objects[i] as Circle;
                            if (((x - circle.x - circle.rad) * (x - circle.x - circle.rad) + (y - circle.y - circle.rad) * (y - circle.y - circle.rad)) < (circle.rad * circle.rad))
                                return i;
                        }
                        else
                        {
                            if (storag.objects[i] as Line != null)
                            {   // Если в хранилище отрезок
                                Line line = storag.objects[i] as Line;                                
                                if (line.x <= x && x <= line.x2 && (line.y - 4) <= y && y <= (line.y + 4))
                                    return i;
                            }
                            else
                            {
                                if (storag.objects[i] as Square != null)
                                {   // Если в хранилище квадрат
                                    Square square = storag.objects[i] as Square;
                                    if (square.x <= x && x <=(square.x + square.size) &&
                                        square.y <= y && y <= (square.y + square.size))                                    
                                        return i;
                                }
                            }
                        }
                       
                    }
                }
            }
            return -1;
        }

        private void drawellipse_Click(object sender, EventArgs e)
        {
            drawline.Checked = false;
            drawsquare.Checked = false;
            figure_now = 1;
        }

        private void drawline_Click(object sender, EventArgs e)
        {
            drawsquare.Checked = false;
            drawellipse.Checked = false;
            figure_now = 2;
        }

        private void drawsquare_Click(object sender, EventArgs e)
        {
            drawline.Checked = false;
            drawellipse.Checked = false;
            figure_now = 3;
        }

        private void laba6_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {   // Удаление выделенных фигур, если нажата кнопка delete
                remove_selected_circle(ref storag);
                panel_drawing.Refresh();
                if (storag.occupied(k) != 0)
                {
                    for (int i = 0; i < k; ++i)
                    {
                        paint_figure(Color.Navy, 4, ref storag, i);
                    }
                }
            }
        }
    }
}