using System;


namespace MarioPartySaveEditor
{
    public class GameSave
    {
        public int Bucks { get; set; }
        private byte[] contents;
        private GameSave(byte[] Data)
        {
            contents = Data;
            Bucks = BitConverter.ToInt32(contents, 0x0C);
        }

        public static bool Read(string Path, out GameSave Save)
        {
            Save = null;
            if (!System.IO.File.Exists(Path)) return false;
            byte[] Data = System.IO.File.ReadAllBytes(Path);

            if (Data.Length != 0x2335C0) return false;

            Save = new GameSave(Data);
            return true;

        }

        public static bool Save(GameSave Save, string Path)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(Save.contents))
            {
                ms.Seek(0x0C, System.IO.SeekOrigin.Begin);
                ms.Write(BitConverter.GetBytes(Save.Bucks), 0, 4);
            }
            System.IO.File.WriteAllBytes(Path, Save.contents);
            return true;
        }
    }
}
