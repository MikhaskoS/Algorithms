using System;


namespace Lesson06
{
	/* Бинарное дерево поиска на основе массива.
	 * Свойства бинарного дерева:
	 * 1. Если х- узел бинарного дерева поиска, а узел у находится в 
	 *    левом поддереве, то key[y] <= key[x].
	 * 2. Если х- узел бинарного дерева поиска, а узел у находится в 
	 *    правом поддереве, то key[x] <= key[y].
	 * 
	 * Узел в бинарном дереве является объектом. Каждый узел содержит
	 * поля (помимо ключа key): 
	 * left - указатель на левый дочерний узел, 
	 * right - указатель на правый дочерний узел, 
	 * p - указатель на родительский узел.
	 * 
	 * Пример:        (дерево с высотой 2)                              (то же дерево с высотой 4)
	 *                          5          - корень (key = 5)              2        
	 *                    /           \                                     \
	 *                   3(3<5)     7(7>5)                                  3
	 *                 /      \         \                                  /  \
	 *               2(2<3)  5(5>3)    8(8>7)                             5    8
	 *                                                                   / 
	 *                                                                  5
	 * */
	class BinaryTreeArray
	{
		int NIL = int.MaxValue;      // условно, в качестве пустого элемента используем макс. знчение
		int n = 0;                   // количество элементов в дереве
		int root;                    // индекс корня
		int next;                    // индекс последнего вошедшего элемента

		// каждому элементу из дерева ставится в соответствие значение
		// из массива.
		double[] key;
		int[] left;
		int[] right;
		int[] parent;

		public int Size { get { return n; } set { n = value; } }
		public int Root { get { return root; } set { root = value; } }
		public int Next { get { return next; } set { next = value; } }

		// Дерево с пустым корнем(пустое дерево)
		public BinaryTreeArray(int Size)
		{
			n = Size;
			next = -1;
			Root = NIL;
			key = new double[n];
			left = new int[n];
			right = new int[n];
			parent = new int[n];
		}

		/// <summary>
		/// Вставка нового значения в бинарное дерево поиска.
		/// Время О(h), h - высота дерева.
		/// </summary>
		/// <param name="value"></param>
		public void TreeInsert(double value)
		{
			// новый элемент имеет свой индекс
			Next += 1;
			int z = Next;  // это он
			left[z] = NIL;
			right[z] = NIL;
			key[z] = value;   // ключ

			int y = NIL;
			int x = Root; // запомним индекс корня


			// спускаемся вниз по дереву, пока не упремся в пустой указатель
			while (x != NIL) // если дерево не пустое...
			{
				y = x; // запоминаем текущий указатель (это родитель)

				// устанавливаем указатель
				if (key[z] < key[x])
				{
					x = left[x];
				}
				else
				{
					x = right[x];
				}
			}
			// запомненный текущий указатель - это
			// указатель на родительский узел.
			parent[z] = y;

			// если дерева вообще не было...
			if (y == NIL)
			{
				Root = z;
			}
			else // если же было...
			{
				// поменяем указатели родительского узла
				// на дочерние
				if (key[z] < key[y])
				{
					left[y] = z;
				}
				else
				{
					right[y] = z;
				}
			}
		}


		/// <summary>
		/// Удаление узла.
		/// Время О(h), h - высота дерева.
		/// </summary>
		/// <param name="z">Индекс удаляемого элемента</param>

		public void TreeDelete(int z)
		{
			int y;
			int x;
			// при удалении узла z происходит склейка родительского
			// узла и дочернего. Происходит это не простым соединением.
			// возможен случай, когда z будет заменена другим узлом y.

			// если z - лист дерева
			if ((left[z] == NIL) || (right[z] == NIL))
			{
				// запомним индекс удаляемого элемента.
				y = z;
			}
			else
			{
				// в противном случае ищем следующий
				// в отсортированной последовательности узел.
				// он заменит удаляемый элемент.
				y = TreeSuccessor(z);
			}
			if (left[y] != NIL)
			{
				x = left[y];
			}
			else
			{
				x = right[y];
			}
			if (x != NIL)
			{
				parent[x] = parent[y];
			}
			if (parent[y] == NIL)
			{
				Root = x;
			}
			else
			{
				if (y == left[parent[y]])
				{
					left[parent[y]] = x;
				}
				else
				{
					right[parent[y]] = x;
				}
			}
			if (y != z)
			{
				key[z] = key[y];
			}
		}


		/// <summary>
		/// Индекс минимального элемента.
		/// </summary>
		/// <returns></returns>
		public int TreeMinimum()
		{
			int x = Root;
			while (left[x] != NIL)
			{
				x = left[x];
			}
			return x;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public int TreeMinimum(int x)
		{
			while (left[x] != NIL)
			{
				x = left[x];
			}
			return x;
		}

		/// <summary>
		/// Индекс максимального элемента.
		/// </summary>
		/// <returns></returns>
		public int TreeMaximum()
		{
			int x = Root;
			while (right[x] != NIL)
			{
				x = right[x];
			}
			return x;
		}

		/// <summary>
		/// индекс максимального элемента от указанного
		/// узла.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public int TreeMaximum(int x)
		{
			while (right[x] != NIL)
			{
				x = right[x];
			}
			return x;
		}


		/// <summary>
		/// Поиск индекса узла по заданному ключу.
		/// </summary>
		/// <param name="x">Индекс узла дерева</param>
		/// <param name="k">ключ</param>
		/// <returns>индекс ключа</returns>
		public int TreeSearch(int x, double k)
		{
			if ((x == NIL) || (k == key[x]))
				return x;
			if (k < key[x])
				return TreeSearch(left[x], k);
			else
				return TreeSearch(right[x], k);
		}


		/// <summary>
		/// Поиск узла, следующего за узлом в отсортированной(!!!) последовательности.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public int TreeSuccessor(int x)
		{
			// если узел имеет дочерний элемент справа.
			if (right[x] != NIL)
			{
				return TreeMinimum(right[x]);
			}
			// родительский узел
			int y = parent[x];
			while ((y != NIL) && (x == right[y]))
			{
				x = y;
				y = parent[y];
			}
			return y;
		}

		/// <summary>
		/// Вспомогательная функция, отображающая узел
		/// бинарного дерева поиска в соответствии с его индексом
		/// в динамическом массиве дерева.
		/// </summary>
		/// <param name="index"></param>
		public void ViewKnot(int index)
		{
			Console.WriteLine("индекс   : " + index);
			Console.WriteLine("key   [" + index + "]: " + key[index]);
			Console.WriteLine("left  [" + index + "]: " + left[index]);
			Console.WriteLine("right [" + index + "]: " + right[index]);
			Console.WriteLine("parent[" + index + "]: " + parent[index]);

		}

		public double ViewKey(int index)
		{
			return key[index];
		}

	}
}
