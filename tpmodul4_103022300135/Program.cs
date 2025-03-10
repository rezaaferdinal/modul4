using System;

public class Kodepos
{
    public static string getKodePos(string daerah)
    {
        string[,] dataKodePos = {
            { "Batununggal", "40266" },
            { "Kujangsari", "40287" },
            { "Mengger", "40267" },
            { "Wates", "40256" },
            { "Cijaura", "40287" },
            { "Jatisari", "40286" },
            { "Margasari", "40286" },
            { "Sekejati", "40286" },
            { "Kebonwaru", "40272" },
            { "Maleer", "40274" },
            { "Samoja", "40273" }
        };

        for (int i = 0; i < dataKodePos.GetLength(0); i++)
        {
            if (dataKodePos[i, 0].Equals(daerah, StringComparison.OrdinalIgnoreCase))
            {
                return dataKodePos[i, 1];
            }
        }
        return "kode pos tidak ditemukan";
    }
}

public class DoorMachine
{
    enum State { terkunci, terbuka, keluar };
    public void door()
    {

        State state = State.terkunci;
        String[] status = { "terkunci", "terbuka", "keluar" };

        while (state != State.keluar)
        {

            Console.WriteLine("\n" + "Pintu " + status[(int)state] + "\n");
            Console.WriteLine("Masukkan perintah (masukkan keluar untuk kembali) : ");
            String command = Console.ReadLine();

            switch (state)
            {
                case State.terkunci:
                    if (command == "terbuka")
                    {
                        state = State.terbuka;
                    }
                    else if (command == "keluar")
                    {
                        Program.Main();
                    }
                    break;
                case State.terbuka:
                    if (command == "terkunci")
                    {
                        state = State.terkunci;
                    }
                    else if (command == "keluar")
                    {
                        Program.Main();
                    }
                    break;
            }
        }
    }
}


public class Program
{
    public static void Main()
    {
        Console.WriteLine("1. program kode pos");
        Console.WriteLine("2. program Door Machine");
        Console.WriteLine("0. exit");
        Console.WriteLine("nasukkan pilihan : ");

        String masuk = Console.ReadLine();

        while (masuk != "0")
        {
            if (masuk == "1")
            {
                Kodepos Kode = new Kodepos();
                Console.WriteLine("masukkan nama kelurahan (kembali untuk ke menu utama) : ");
                string kelurahan = Console.ReadLine() ?? "";

                if (kelurahan != "kembali")
                {
                    string kode = Kodepos.getKodePos(kelurahan);
                    Console.WriteLine($"kode pos {kelurahan} : {kode}");
                }
                else
                {
                    Main();
                }

            }
            else if (masuk == "2")
            {
                DoorMachine door = new DoorMachine();
                door.door();
            }
            else if (masuk == "0")
            {
                break;
            }
        }
    }
}