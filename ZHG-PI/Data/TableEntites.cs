using System;
using Azure.Data.Tables;

namespace ZHG_PI.Data
{

    public class TableEntities
    {
        public static List<TableEntity> allTableEntities()
        {
            List<TableEntity> tableEntities = new List<TableEntity>();
            var entity0 = new TableEntity("Solo", "0")
            {
                {"Title", "RGB" },
                {"Autor", "Yoasobi" },
                {"Duration", 220 }
            };
            var entity1 = new TableEntity("Solo", "1")
            {
                {"Title", "Juste un jour ensoleillé pour toi" },
                {"Autor", "n-buna" },
                {"Duration", 200 }
            };
            var entity2 = new TableEntity("Solo", "2")
            {
                {"Title", "Voilà pourquoi j'ai abandonné la music" },
                {"Autor", "n-buna" },
                {"Duration", 247 }
            };
            var entity3 = new TableEntity("Solo", "3")
            {
                {"Title", "I drink wine" },
                {"Autor", "Adele" },
                {"Duration", 425 }
            };
            tableEntities.Add(entity0);
            tableEntities.Add(entity1);
            tableEntities.Add(entity2);
            tableEntities.Add(entity3);
            return tableEntities;
        }
    }

}
