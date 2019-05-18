
using App.Diagrams.PlantUml;
using App.Diagrams.PlantUml.Uml;
using App.Diagrams.PlantUml.Uml.Services;
using MB.Diagrams.PlantUml.Uml;

namespace XAct.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <internal>
    /// Src: http://www.siepman.nl/blog/post/2013/07/30/tree-node-nodes-descendants-ancestors.aspx
    /// </internal>
    /// <para>
    /// But maybe one day look again at: http://www.codeproject.com/Articles/12592/Generic-Tree-T-in-C
    /// </para>
    public class TreeNode<T> : IEqualityComparer, IEnumerable<T>, IEnumerable<TreeNode<T>>
    {
        public TreeNode<T> Parent { get; private set; }
        public T Value { get; set; }
        private readonly List<TreeNode<T>> _children = new List<TreeNode<T>>();

        public TreeNode(T value)
        {
            Value = value;
        }

        public TreeNode<T> this[int index]
        {
            get
            {
                return _children[index];
            }
        }

        /// <summary>
        /// Adds a child node.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public TreeNode<T> Add(T value, int index = -1)
        {
            var childNode = new TreeNode<T>(value);
            Add(childNode, index);
            return childNode;
        }

        /// <summary>
        /// Adds a child node.
        /// </summary>
        /// <param name="childNode"></param>
        /// <param name="index"></param>
        public void Add(TreeNode<T> childNode, int index = -1)
        {
            if (index < -1)
            {
                throw new ArgumentException("The index can not be lower then -1");
            }
            if (index > Children.Count() - 1)
            {
                throw new ArgumentException("The index ({0}) can not be higher then index of the last iten. Use the AddChild() method without an index to add at the end".FormatStringInvariantCulture(index));
            }
            if (!childNode.IsRoot)
            {
                throw new ArgumentException("The child node with value [{0}] can not be added because it is not a root node.".FormatStringInvariantCulture(childNode.Value));
            }

            if (Root == childNode)
            {
                throw new ArgumentException("The child node with value [{0}] is the rootnode of the parent.".FormatStringInvariantCulture(childNode.Value));
            }

            if (childNode.SelfAndDescendants.Any(n => this == n))
            {
                throw new ArgumentException("The childnode with value [{0}] can not be added to itself or its descendants.".FormatStringInvariantCulture(childNode.Value));
            }
            childNode.Parent = this;
            if (index == -1)
            {
                _children.Add(childNode);
            }
            else
            {
                _children.Insert(index, childNode);
            }
        }

        public TreeNode<T> AddFirstChild(T value)
        {
            var childNode = new TreeNode<T>(value);
            AddFirstChild(childNode);
            return childNode;
        }

        public void AddFirstChild(TreeNode<T> childNode)
        {
            Add(childNode, 0);
        }

        public TreeNode<T> AddFirstSibling(T value)
        {
            var childNode = new TreeNode<T>(value);
            AddFirstSibling(childNode);
            return childNode;
        }

        public void AddFirstSibling(TreeNode<T> childNode)
        {
            Parent.AddFirstChild(childNode);
        }
        public TreeNode<T> AddLastSibling(T value)
        {
            var childNode = new TreeNode<T>(value);
            AddLastSibling(childNode);
            return childNode;
        }

        public void AddLastSibling(TreeNode<T> childNode)
        {
            Parent.Add(childNode);
        }

        public TreeNode<T> AddParent(T value)
        {
            var newNode = new TreeNode<T>(value);
            AddParent(newNode);
            return newNode;
        }

        public void AddParent(TreeNode<T> parentNode)
        {
            if (!IsRoot)
            {
                throw new ArgumentException("This node [{0}] already has a parent".FormatStringInvariantCulture(Value), "parentNode");
            }
            parentNode.Add(this);
        }

        public IEnumerable<TreeNode<T>> Ancestors
        {
            get
            {
                if (IsRoot)
                {
                    return Enumerable.Empty<TreeNode<T>>();
                }
                return Parent.ToIEnumarable().Concat(Parent.Ancestors);
            }
        }

        public IEnumerable<TreeNode<T>> Descendants
        {
            get
            {
                return SelfAndDescendants.Skip(1);
            }
        }

        public IEnumerable<TreeNode<T>> Children
        {
            get
            {
                return _children;
            }
        }

        public IEnumerable<TreeNode<T>> Siblings
        {
            get
            {
                return SelfAndSiblings.Where(Other);

            }
        }

        private bool Other(TreeNode<T> node)
        {
            return !ReferenceEquals(node, this);
        }

        public IEnumerable<TreeNode<T>> SelfAndChildren
        {
            get
            {
                var result = this.ToIEnumarable().Concat(Children);
                return result;
            }
        }

        public IEnumerable<TreeNode<T>> SelfAndAncestors
        {
            get
            {
                var result = this.ToIEnumarable().Concat(Ancestors);
                return result;
            }
        }

        public IEnumerable<TreeNode<T>> SelfAndDescendants
        {
            get
            {
                var result = this.ToIEnumarable().Concat(Children.SelectMany(c => c.SelfAndDescendants));
                return result;
            }
        }

        public IEnumerable<TreeNode<T>> SelfAndSiblings
        {
            get
            {
                if (IsRoot)
                {
                    return this.ToIEnumarable();
                }
                return Parent.Children;

            }
        }

        public IEnumerable<TreeNode<T>> All
        {
            get
            {
                return Root.SelfAndDescendants;
            }
        }


        public IEnumerable<TreeNode<T>> SameLevel
        {
            get
            {
                return SelfAndSameLevel.Where(Other);

            }
        }

        public int Level
        {
            get
            {
                return Ancestors.Count();
            }
        }

        public IEnumerable<TreeNode<T>> SelfAndSameLevel
        {
            get
            {
                var result = GetNodesAtLevel(Level);
                return result;
            }
        }

        public IEnumerable<TreeNode<T>> GetNodesAtLevel(int level)
        {
            return Root.GetNodesAtLevelInternal(level);
        }

        private IEnumerable<TreeNode<T>> GetNodesAtLevelInternal(int level)
        {
            if (level == Level)
            {
                return this.ToIEnumarable();
            }
            return Children.SelectMany(c => c.GetNodesAtLevelInternal(level));
        }

        public TreeNode<T> Root
        {
            get
            {
                return SelfAndAncestors.Last();
            }
        }

        public void Disconnect()
        {
            if (IsRoot)
            {
                throw new InvalidOperationException("The root node [{0}] can not get disconnected from a parent.".FormatStringInvariantCulture(Value));
            }
            Parent._children.Remove(this);
            Parent = null;
        }

        public bool IsRoot
        {
            get { return Parent == null; }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _children.Values().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _children.GetEnumerator();
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            return _children.GetEnumerator();
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static IEnumerable<TreeNode<T>> CreateTree<TId>(IEnumerable<T> values, Func<T, TId> idSelector, Func<T, TId?> parentIdSelector)
            where TId : struct
        {
            var valuesCache = values.ToList();
            if (!valuesCache.Any())
                return Enumerable.Empty<TreeNode<T>>();
            T itemWithIdAndParentIdIsTheSame = valuesCache.FirstOrDefault(v => IsSameId(idSelector(v), parentIdSelector(v)));
            if (itemWithIdAndParentIdIsTheSame != null) // Hier verwacht je ook een null terug te kunnen komen
            {
                throw new ArgumentException("At least one value has the samen Id and parentId [{0}]".FormatStringInvariantCulture(itemWithIdAndParentIdIsTheSame));
            }

            var nodes = valuesCache.Select(v => new TreeNode<T>(v));
            return CreateTree(nodes, idSelector, parentIdSelector);

        }

        public static IEnumerable<TreeNode<T>> CreateTree<TId>(IEnumerable<TreeNode<T>> rootNodes, Func<T, TId> idSelector, Func<T, TId?> parentIdSelector)
            where TId : struct
        {
            var rootNodesCache = rootNodes.ToList();
            var duplicates = rootNodesCache.GetDuplicates(n => n).ToList();
            if (duplicates.Any())
            {
                throw new ArgumentException("One or more values contains {0} duplicate keys. The first duplicate is: [{1}]".FormatStringInvariantCulture(duplicates.Count, duplicates[0]));
            }

            foreach (var rootNode in rootNodesCache)
            {
                var parentId = parentIdSelector(rootNode.Value);
                var parent = rootNodesCache.FirstOrDefault(n => IsSameId(idSelector(n.Value), parentId));

                if (parent != null)
                {
                    parent.Add(rootNode);
                }
                else if (parentId != null)
                {
                    throw new ArgumentException("A value has the parent ID [{0}] but no other nodes has this ID".FormatStringInvariantCulture(parentId.Value));
                }
            }
            var result = rootNodesCache.Where(n => n.IsRoot);
            return result;
        }


        private static bool IsSameId<TId>(TId id, TId? parentId)
            where TId : struct
        {
            return parentId != null && id.Equals(parentId.Value);
        }

        #region Equals en ==

        public static bool operator ==(TreeNode<T> value1, TreeNode<T> value2)
        {
            if ((object)(value1) == null && (object)value2 == null)
            {
                return true;
            }
            return ReferenceEquals(value1, value2);
        }

        public static bool operator !=(TreeNode<T> value1, TreeNode<T> value2)
        {
            return !(value1 == value2);
        }

        public override bool Equals(Object anderePeriode)
        {
            var valueThisType = anderePeriode as TreeNode<T>;
            return this == valueThisType;
        }

        public bool Equals(TreeNode<T> value)
        {
            return this == value;
        }

        public bool Equals(TreeNode<T> value1, TreeNode<T> value2)
        {
            return value1 == value2;
        }

        bool IEqualityComparer.Equals(object value1, object value2)
        {
            var valueThisType1 = value1 as TreeNode<T>;
            var valueThisType2 = value2 as TreeNode<T>;

            return Equals(valueThisType1, valueThisType2);
        }

        public int GetHashCode(object obj)
        {
            var result = GetHashCode(obj as TreeNode<T>);
            return result;
        }

        public override int GetHashCode()
        {
            var result = GetHashCode(this);
            return result;
        }

        public int GetHashCode(TreeNode<T> value)
        {
            var result = base.GetHashCode();
            return result;
        }
        #endregion
    }

}
