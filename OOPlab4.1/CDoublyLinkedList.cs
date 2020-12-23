using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPlab4._1
{
    class DoublyNode
    {
        private AShape shape;
        public DoublyNode prev;
        public DoublyNode next;

        //  constructor
        public DoublyNode(AShape shape)
        {
            this.shape = shape;
            prev = null;
            next = null;
        }

        public AShape Shape { get => shape; }
    }

    class DoublyLinkedList
    {
        private int count;
        private DoublyNode head;
        private DoublyNode current;
        private DoublyNode tail;

        //  construsctor
        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            current = null;
            count = 0;
        }

        //  Add new shape to the back of the list
        public bool Push_back(AShape shape)
        {
            if (shape == null)
                return false;
            DoublyNode fresh = new DoublyNode(shape);
            if (count > 0)
            {
                fresh.prev = tail;
                tail.next = fresh;
                tail = fresh;
            }
            else
            {
                tail = fresh;
                head = fresh;
            }
            current = fresh;
            ++count;
            return true;
        }

        //  Add new shape to the front of the list
        public bool Push_front(AShape shape)
        {
            if (shape == null)
                return false;
            DoublyNode fresh = new DoublyNode(shape);
            if (count > 0)
            {
                head.prev = fresh;
                fresh.next = head;
                head = fresh;
            }
            else
            {
                tail = fresh;
                head = fresh;
            }
            current = fresh;
            ++count;
            return true;
        }

        //  Delete last shape from list
        public bool Delete_last()
        {
            if (tail == null)
                return false;
            if (count > 1)
            {
                tail.prev.next = null;
                tail = tail.prev;
                if (current == null)
                    current = tail;
            }
            else
            {
                tail = null;
                head = null;
                current = null;
            }
            --count;
            return true;
        }

        //  Delete first shape from list
        public bool Delete_first()
        {
            if (head == null)
                return false;
            if (count > 1)
            {
                head.next.prev = null;
                head = head.next;
                if (current == null)
                    current = head;
            }
            else
            {
                tail = null;
                head = null;
                current = null;
            }
            --count;
            return true;
        }

        //  Move current to the next shape
        public bool Step_forward()
        {
            if (current.next == null)
                return false;
            current = current.next;
            return true;
        }

        //  Move current to the previous shape
        public bool Step_back()
        {
            if (current.prev == null)
                return false;
            current = current.prev;
            return true;
        }

        //  Draw all shapes in list
        public bool Draw_whole_list()
        {
            if (count == 0)
                return false;
            bool cond = true;
            for (current = head; cond; cond = Step_forward())
                current.Shape.Draw();
            return true;
        }

        //  Set current to the head
        public bool Set_current_first()
        {
            if (head == null)
                return false;
            current = head;
            return true;
        }

        //  Set current to the tail
        public bool Set_current_last()
        {
            if (tail == null)
                return false;
            current = tail;
            return true;
        }

        //  no need to describe
        public AShape Get_current_shape()
        {
            if (current == null)
                return null;
            return current.Shape;
        }

        //  Check if list is empty
        public bool Is_empty()
        {
            if (count == 0)
                return true;
            return false;
        }

        public DoublyNode Current { get => current; }
        public DoublyNode Head { get => head; }
        public DoublyNode Tail { get => tail; }
        public int Count { get => count; }
    }
}
