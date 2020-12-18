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
			public int x, y;
			public Color color = Color.Navy;
			public Color fillcolor = Color.White;
		}
		class Circle: Figure
		{
			//public int x, y; // Координаты круга
			public int rad = 30; // Радиус круга
			public Circle(int x, int y)
			{
				this.x = x - rad;
				this.y = y - rad;
			}

			~Circle() { }
		}

		class Line: Figure
		{
			//public int x, y;
			public int lenght = 60;
			public int wight = 5;
			public Line(int x, int y)
			{
				this.x = x - lenght/2;
				this.y = y;
			}
		}

		class Square: Figure
		{
			//public int x, y, 
			public int width, height;
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
		int figure_now = 1;	// Какая фигура выбрана

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
			{	// В зависимости какая фигура выбрана
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
			{   // Если на этом месте уже нарисована фигура
				if (Control.ModifierKeys == Keys.Control)
				{   // Если нажат ctrl, то выделяем несколько объектов
					if (p == 0)
					{
						paint_figure(Color.Navy, 4, ref storag, indexin);
						p = 1;
					}
					// Вызываем функцию отрисовки фигуры  
					paint_figure(Color.Red, 4, ref storag, c);
				}
				else
				{   // Иначе выделяем только один объект
					// Снимаем выделение у всех объектов хранилища
					remove_selection_circle(ref storag);
					paint_figure(Color.Red, 4, ref storag, c);
				}
				return;
			}
			// Добавляем фигуру в хранилище   
			storag.add_object(index, ref figure, k, ref indexin);
			// Снимаем выделение у всех объектов хранилища
			remove_selection_circle(ref storag);
			storag.objects[indexin].fillcolor = colorDialog1.Color;
			paint_figure(Color.Red, 4, ref storag, indexin);
			++index;
			p = 0;
		}

		private void remove_selection_circle(ref Storage stg)
		{   // Снимает выделение у всех элементов хранилища
			for (int i = 0; i < k; ++i)
			{
				if (!stg.check_empty(i))
				{   // Вызываем функцию отрисовки круга
					paint_figure(Color.Navy, 4, ref storag, i);
				}
			}
		}

		private void move_y(ref Storage stg, int y)
		{	// Функция для перемещения фигур по оси Y
			for(int i = 0; i < k; ++i)
			{
				if (!stg.check_empty(i))
				{
					if(stg.objects[i].color == Color.Red)
                    {	// Если объект выделен
						if (stg.objects[i] as Circle != null)
						{   // Если в хранилище круг
							Circle circle = stg.objects[i] as Circle;
							int c = circle.y + y;
							int gran = panel_drawing.ClientSize.Height - circle.rad * 2;
							// Проверяем на выход из границы поля
							check(c, y, gran, gran - 2, ref stg.objects[i], 2);
						}
						else
						{
							if (stg.objects[i] as Line != null)
							{   // Если в хранилище отрезок
								Line line = stg.objects[i] as Line;
								int l = line.y + y;
								int gran = panel_drawing.ClientSize.Height - line.wight;
								// Проверяем на выход из границы поля
								check(l, y, gran, --gran, ref stg.objects[i], 2);
							}
							else
							{
								if (stg.objects[i] as Square != null)
								{   // Если в хранилище квадрат
									Square square = stg.objects[i] as Square;
									int s = square.y + y;
									int gran = panel_drawing.ClientSize.Height - square.size;
									// Проверяем на выход из границы поля
									check(s, y, gran, --gran, ref stg.objects[i], 2);
								}
							}
						}
					}
				}
			}
		}

        private void move_x(ref Storage stg, int x)
		{   // Функция для перемещения фигур по оси X
			for (int i = 0; i < k; ++i)
            {
                if (!stg.check_empty(i))
                {
                    if (stg.objects[i].color == Color.Red)
					{   // Если объект выделен
						if (stg.objects[i] as Circle != null)
                        {   // Если в хранилище круг
                            Circle circle = stg.objects[i] as Circle;
                            int c = circle.x + x;
							int gran = panel_drawing.ClientSize.Width - (circle.rad * 2);
							// Проверяем на выход из границы поля
							check(c, x, gran, gran - 2, ref stg.objects[i], 1);
						}
                        else
                        {
                            if (stg.objects[i] as Line != null)
                            {   // Если в хранилище отрезок
                                Line line = stg.objects[i] as Line;
                                int l = line.x + x;
								int gran = panel_drawing.ClientSize.Width - line.lenght;
								// Проверяем на выход из границы поля
								check(l, x, gran, --gran, ref stg.objects[i], 1);
							}
                            else
                            {
                                if (stg.objects[i] as Square != null)
                                {   // Если в хранилище квадрат
                                    Square square = stg.objects[i] as Square;
                                    int s = square.x + x;
									int gran = panel_drawing.ClientSize.Width - square.size;
									// Проверяем на выход из границы поля
									check(s, x, gran, --gran, ref stg.objects[i], 1);
								}
                            }
                        }
                    }
                }
            }
        }

		private void check(int f, int y, int gran, int gran1, ref Figure figures, int g)
        {	// Проверка на выход фигуры за границы
			ref int b = ref figures.x;
			if (g == 2)			
				 b = ref figures.y;
			if (f > 0 && f < gran)
				b += y;
			else
			{
				if (f <= 0)
					b = 1;
				else
					if (f >= gran1)
						b = gran1;
			}
		}

		private void changesize(ref Storage stg, int size)
		{	// Увеличивает или уменьшает размер фигур, в зависимости от size
			for (int i = 0; i < k; ++i)
			{
				if (!stg.check_empty(i))
				{   // Если под i индексом в хранилище есть объект
					if (stg.objects[i].color == Color.Red)
					{
						if (stg.objects[i] as Circle != null)
						{   // Если в хранилище круг
							Circle circle = stg.objects[i] as Circle;
							circle.rad += size;
						}
						else
						{
							if (stg.objects[i] as Line != null)
							{   // Если в хранилище отрезок
								Line line = stg.objects[i] as Line;
								line.lenght += size;
								line.wight += size / 5;
							}
							else
							{
								if (stg.objects[i] as Square != null)
								{   // Если в хранилище квадрат
									Square square = stg.objects[i] as Square;
									square.size += size;
									square.width = square.size;
									square.height = square.size;
								}
							}
						}
					}
				}
			}
		}

        private void remove_selected_circle(ref Storage stg)
		{   // Удаляет выделенные элементы из хранилища
			for (int i = 0; i < k; ++i)
			{
				if (!stg.check_empty(i))
				{
					if (stg.objects[i].color == Color.Red)
						stg.delete_object(i);
				}
			}
		}
		private void paint_figure(Color name, int size, ref Storage stg, int index)
		{   // Рисует фигуру на панели          
			// Объявляем объект - карандаш, которым будем рисовать контур
			Pen pen = new Pen(name, size);
			SolidBrush figurefillcolor;
			if (!stg.check_empty(index))
			{
				stg.objects[index].color = name;
				figurefillcolor = new SolidBrush(stg.objects[index].fillcolor);				
				if (stg.objects[index] as Circle != null)
				{   // Если в хранилище круг
					Circle circle = stg.objects[index] as Circle;
					panel_drawing.CreateGraphics().DrawEllipse(
					pen, circle.x, circle.y, circle.rad * 2, circle.rad * 2);					
					panel_drawing.CreateGraphics().FillEllipse(
						figurefillcolor, circle.x, circle.y, circle.rad * 2, circle.rad * 2);
				}
				else 
				{
					if (stg.objects[index] as Line != null)
					{   // Если в хранилище отрезок
						Line line = stg.objects[index] as Line;
						panel_drawing.CreateGraphics().DrawRectangle(pen, line.x,
												line.y, line.lenght, line.wight);
						panel_drawing.CreateGraphics().FillRectangle(figurefillcolor, line.x,
							line.y, line.lenght, line.wight);
					}
					else
					{
						if (stg.objects[index] as Square != null)
						{   // Если в хранилище квадрат
							Square square = stg.objects[index] as Square;
							panel_drawing.CreateGraphics().DrawRectangle(pen,
								square.x, square.y, square.width,
								square.height);
							panel_drawing.CreateGraphics().FillRectangle(figurefillcolor,
								square.x, square.y, square.width,
								square.height);
						}
					}
				}
			}
		}

		private void paint_all(ref Storage stg)
        {	// Рисует все фигуры на панели
			for (int i = 0; i < k; ++i)
				if (!stg.check_empty(i))
					paint_figure(stg.objects[i].color, 4, ref storag, i);
		}

		private int check_figure(ref Storage stg, int size, int x, int y)
		{   // Проверяет есть ли уже фигура с такими же координатами в хранилище
			if (stg.occupied(size) != 0)
			{
				for (int i = 0; i < size; ++i)
				{
					if (!stg.check_empty(i))
					{   // Если под i индексом в хранилище есть объект
						if (stg.objects[i] as Circle != null)
						{   // Если в хранилище круг
							Circle circle = stg.objects[i] as Circle;
							if (((x - circle.x - circle.rad) * (x - circle.x - circle.rad) + 
								(y - circle.y - circle.rad) * (y - circle.y - circle.rad)) 
								< (circle.rad * circle.rad))
								return i;
						}
						else
						{
							if (stg.objects[i] as Line != null)
							{   // Если в хранилище отрезок
								Line line = stg.objects[i] as Line;                                
								if (line.x <= x && x <= (line.x + line.lenght) && (line.y - 2) <= y &&
									y <= (line.y + line.wight))
									return i;
							}
							else
							{
								if (stg.objects[i] as Square != null)
								{   // Если в хранилище квадрат
									Square square = stg.objects[i] as Square;
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
			if (drawellipse.Checked == false) // Если не выбрана фигура
				figure_now = 0;
		}

		private void drawline_Click(object sender, EventArgs e)
		{
			drawsquare.Checked = false;
			drawellipse.Checked = false;
			figure_now = 2;
			if (drawline.Checked == false) // Если не выбрана фигура
				figure_now = 0;
		}

		private void drawsquare_Click(object sender, EventArgs e)
		{
			drawline.Checked = false;
			drawellipse.Checked = false;
			figure_now = 3;
			if (drawsquare.Checked == false) // Если не выбрана фигура
				figure_now = 0;
		}

		private void laba6_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Delete)
			{   // Удаление выделенных фигур, если нажата кнопка delete
				remove_selected_circle(ref storag);
			}
			if(e.KeyCode == Keys.W)
			{	// Перемещение по оси X вверх
				move_y(ref storag, -10);
			}
			if (e.KeyCode == Keys.S)
			{	// Перемещение по оси X вниз
				move_y(ref storag, +10);
			}
			if (e.KeyCode == Keys.A)
			{	// Перемещение по оси Y вниз
				move_x(ref storag, -10);
			}
			if (e.KeyCode == Keys.D)
			{   // Перемещение по оси Y вверх
				move_x(ref storag, +10);
			}
			if (e.KeyCode == Keys.Oemplus)
			{	// Увеличиваем размер фигуры
				changesize(ref storag, 10);
			}
			if (e.KeyCode == Keys.OemMinus)
			{	// Уменьшаем размер фигуры
				changesize(ref storag, -10);
			}
			panel_drawing.Refresh();
			paint_all(ref storag);
		}

        private void btn_select_color_Click(object sender, EventArgs e)
        {	// Смена цвета у фигур
			if (colorDialog1.ShowDialog() == DialogResult.Cancel)
				return;
			btn_select_color.BackColor = colorDialog1.Color;
			for (int i = 0; i < k; ++i)
			{
				if (!storag.check_empty(i))
					if (storag.objects[i].color == Color.Red)
					{
						storag.objects[i].fillcolor = colorDialog1.Color;
						paint_figure(storag.objects[i].color, 4, ref storag, i);
					}
			}
		}
    }
}