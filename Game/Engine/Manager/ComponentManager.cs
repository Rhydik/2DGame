using Engine.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Manager
{
    public class ComponentManager
    {
        private static readonly ComponentManager instance;

        private Dictionary<int, List<IComponent>> entity;

        static ComponentManager()
        {
            instance = new ComponentManager();
        }

        private ComponentManager()
        {
            entity = new Dictionary<int, List<IComponent>>();
        }

        public static ComponentManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void AddComponentToEntity(int id, IComponent component)
        {
            if (entity.ContainsKey(id))
            {
                List<IComponent> listOfComponents = entity[id];

                listOfComponents.Add(component);
            }
        }

        public void RemoveComponentFromEntity(int id, IComponent component)
        {
            if (entity.ContainsKey(id))
            {
                List<IComponent> listOfComponents = entity[id];

                listOfComponents.Remove(component);
            }
        }

        public void CreateNewEntity()
        {
            List<IComponent> list = new List<IComponent>();

            entity.Add(nextId, list);
        }

        public void RemoveEntity(int id)
        {
            if (entity.ContainsKey(id))
            {
                entity.Remove(id);
            }
        }

        public static int nextId = 1;

        private void NextId()
        {
            nextId++;
        }

        public List<T> GetComponentsOfType<T>(IComponent component) where T: IComponent
        {
            List<T> list = new List<T>();
            foreach (var c in entity)
            {
                if (c.Value.Contains(component))
                {
                    var tempComp = c.Value;

                    foreach (var t in tempComp)
                    {
                        //list.Add(t.GetType);
                    }
                }
            }
            return list;
        } 
    }
}
