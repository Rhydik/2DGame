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
        private static readonly ComponentManager instance = new ComponentManager();

        private Dictionary<int, List<IComponent>> entity = new Dictionary<int, List<IComponent>>();

        private ComponentManager() { }

        private static ComponentManager Instance
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

        public static int nextId = 0;

        private void NextId()
        {
            nextId++;
        }
    }
}
