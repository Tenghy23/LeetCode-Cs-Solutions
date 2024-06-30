namespace Leetcode.BinarySearch
{
    public class BST
    {
        public int value;
        public BST left;
        public BST right;

        public BST(int value)
        {
            this.value = value;
        }

        public BST Insert(int value)
        {
            BST currentNode = this;

            while (true)
            {
                if (value < currentNode.value)
                {
                    if (currentNode.left == null)
                    {
                        currentNode.left = new BST(value);
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.left;
                    }
                }
                else
                {
                    if (currentNode.right == null)
                    {
                        currentNode.right = new BST(value);
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.right;
                    }
                }
            }

            return this;
        }

        public void InsertRecursive(int value)
        {
            if (value < this.value)
            {
                if (left == null)
                {
                    left = new BST(value);
                }
                else
                {
                    left.InsertRecursive(value);
                }
            }
            else
            {
                if (right == null)
                {
                    right = new BST(value);
                }
                else
                {
                    right.InsertRecursive(value);
                }
            }
        }

        public bool Contains(int value)
        {
            BST currentNode = this;

            while (currentNode != null)
            {
                if (value < currentNode.value)
                {
                    currentNode = currentNode.left;
                }
                else if (value > currentNode.value)
                {
                    currentNode = currentNode.right;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public BST Remove(int value)
        {
            Remove(value, null);
            return this;
        }

        public BST Remove(int value, BST parentNode)
        {
            BST currentNode = this;

            while (currentNode != null)
            {
                if (value < currentNode.value)
                {
                    if (currentNode.left != null)
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.left;
                    }
                }
                else if (value > currentNode.value)
                {
                    if (currentNode.right != null)
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.right;
                    }
                }
                else
                {
                    if (currentNode.left != null && currentNode.right != null)
                    {
                        currentNode.value = currentNode.right.getMinValue();
                        currentNode.right.Remove(currentNode.value, currentNode);
                    }
                    else if (parentNode == null)
                    {
                        if (currentNode.left != null)
                        {
                            currentNode.value = currentNode.left.value;
                            currentNode.right = currentNode.left.right;
                            currentNode.left = currentNode.left.left;
                        }
                        else if (currentNode.right != null)
                        {
                            currentNode.value = currentNode.right.value;
                            currentNode.left = currentNode.right.left;
                            currentNode.right = currentNode.right.right;
                        }
                        else
                        {
                            // single tree node, do nothing    
                        }
                    }
                    else if (parentNode.left == currentNode)
                    {
                        parentNode.left = currentNode.left != null ? currentNode.left : currentNode.right;
                    }
                    else if (parentNode.right == currentNode)
                    {
                        parentNode.right = currentNode.left != null ? currentNode.left : currentNode.right;
                    }
                    break;
                }
            }

            return this;
        }

        public int GetMinValue()
        {
            if (this.left == null)
            {
                return value;
            }
            else
            {
                return this.left.GetMinValue();
            }
        }

        // output index of value that we are searching
        public static int BinarySearch(int intToSearch, int[] sortedArray)
        {
            int lower = 0;
            int upper = sortedArray.Length - 1;

            while (lower <= upper)
            {
                int mid = lower + (upper - lower) / 2;

                if (intToSearch < sortedArray[mid])
                {
                    upper = mid - 1;
                }
                else if (intToSearch > sortedArray[mid])
                {
                    lower = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1; // Returns -1 if no match is found
        }
    }
}
