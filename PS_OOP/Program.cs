using System;

namespace PS_OOP
{
    public class CPhanSo
    {
        protected int tu;
        protected int mau;
        public int TuSo
        {
            get { return tu; }
            set { tu = value; }
        }
        public int MauSo
        {
            get { return mau; }
            set
            {
                if (value != 0)
                    mau = value;
                else
                    Console.WriteLine("Denominator can't be zero");
            }
        }

        public CPhanSo()
        {
            TuSo = 0;
            MauSo = 1;
        }

        public CPhanSo(int tutu, int maumau)
        {
            TuSo = tutu;
            MauSo = maumau;
        }

        public static CPhanSo operator +(CPhanSo P, CPhanSo Q)
        {
            CPhanSo kq = new CPhanSo();
            kq.TuSo = P.TuSo * Q.MauSo + Q.TuSo * P.MauSo;
            kq.MauSo = P.MauSo * Q.MauSo;
            return RutGon(kq);
        }

        public static CPhanSo operator -(CPhanSo P, CPhanSo Q)
        {
            CPhanSo kq = new CPhanSo();
            kq.TuSo = P.TuSo * Q.MauSo - Q.TuSo * P.MauSo;
            kq.MauSo = P.MauSo * Q.MauSo;
            return RutGon(kq);
        }

        public static CPhanSo operator *(CPhanSo P, CPhanSo Q)
        {
            CPhanSo kq = new CPhanSo();
            kq.TuSo = P.TuSo * Q.TuSo;
            kq.MauSo = P.MauSo * Q.MauSo;
            return RutGon(kq);
        }

        public static CPhanSo operator /(CPhanSo P, CPhanSo Q)
        {
            CPhanSo kq = new CPhanSo();
            if (Q.TuSo != 0)
            {
                kq.TuSo = P.TuSo * Q.MauSo;
                kq.MauSo = P.MauSo * Q.TuSo;
                return RutGon(kq);
            }
            else
            {
                Console.WriteLine("Can't divide 0.");
                return kq;
            }
        }

        public static int USCLN(int a, int b)
        {
            int m = Math.Abs(a);
            int n = Math.Abs(b);
            while (n != 0)
            {
                int temp = n;
                n = m % n;
                m = temp;
            }
            return m;
        }

        public static CPhanSo RutGon(CPhanSo P)
        {
            CPhanSo kq = new CPhanSo();
            int uscln = USCLN(P.TuSo, P.MauSo);
            kq.TuSo = P.TuSo / uscln;
            kq.MauSo = P.MauSo / uscln;
            return kq;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string operation = args[0].ToLower();
            CPhanSo PS1 = NhapPS(args[1]);
            CPhanSo PS2 = NhapPS(args[2]);
            CPhanSo result = new CPhanSo();

            switch (operation)
            {
                case "add":
                    result = PS1 + PS2;
                    break;
                case "sub":
                    result = PS1 - PS2;
                    break;
                case "mul":
                    result = PS1 * PS2;
                    break;
                case "div":
                    result = PS1 / PS2;
                    break;
                default:
                    Console.WriteLine("\nInvalid operation.\"");
                    return;
            }

            Console.WriteLine("{0}/{1}", result.TuSo, result.MauSo);

            static CPhanSo NhapPS(string input)
            {
                string[] parts = input.Split('/');
                int TuSo = int.Parse(parts[0]);
                int MauSo = int.Parse(parts[1]);
                return new CPhanSo(TuSo, MauSo);
            }
        }
    }
}