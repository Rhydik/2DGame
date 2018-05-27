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

        private Dictionary<Type, Dictionary<int, IComponent>> entity;

        static ComponentManager()
        {
            instance = new ComponentManager();
        }

        private ComponentManager()
        {
            entity = new Dictionary<Type, Dictionary<int, IComponent>>();
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
            var key = component.GetType();

            if (!entity.ContainsKey(key))
            {
                entity.Add(component.GetType(), new Dictionary<int, IComponent>());
            }
            entity[key].Add(id, component);
        }

        public void RemoveEntity(int id, IComponent component)
        {
            var key = component.GetType();

            if (!entity.ContainsKey(key))
            {
                return;
            }
            entity[key].Remove(id);
        }

        public int CreateNewEntity(IComponent component)
        {
            int entity = NextId();

            AddComponentToEntity(entity, component);

            return entity;
        }

        public static int nextId = 1;

        private int NextId()
        {
            return nextId++;
        }
 
        public Dictionary<int, IComponent> GetComponentsOfType<ComponentType>()
        {
            //Return Dictionary with all entities containing a specific component
            return entity[typeof(ComponentType)];
        }
    }
}
