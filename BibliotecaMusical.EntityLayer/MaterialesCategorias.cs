using System;

namespace BibliotecaMusical.EntityLayer
{
    public class MaterialesCategoria
    {
        public int ID { get; set; }
        public int Material_ID { get; set; }
        public int Categoria_ID { get; set; }

        // Constructor vacío
        public MaterialesCategoria() { }

        // Constructor con parámetros
        public MaterialesCategoria(int id, int material_ID, int categoria_ID)
        {
            ID = id;
            Material_ID = material_ID;
            Categoria_ID = categoria_ID;
        }
    }
}
