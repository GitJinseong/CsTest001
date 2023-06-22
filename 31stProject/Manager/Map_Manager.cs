using _31stProject._31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31stProject
{
    public class Map_Manager
    {
        #region 선언부
        public List<MapClass> List { get; set; } = new List<MapClass>();
        #endregion

        // 생성자
        public Map_Manager()
        {
            Set_CreateList();
            Set_CreateMap();
        }

        public void Set_CreateList()
        {
            List = new List<MapClass>();
        }

        public void Set_CreateMap()
        {
            MapClass map = new MapClass(30);
            List.Add(map);
        }

    }

}
