using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DDoS
{
    internal class MTMergeSort
    {

        public List <string> MergeSort(string[] strList, int nMin = 2)
        {
            
            List<string> sortedList =  new List<string>(strList);
            if(sortedList.Count < 2)
            {
                return sortedList;
            }

            string[] currList = new string[sortedList.Count]; // temp array for the sub-arrays
            Parallel.Invoke(() => Sort(sortedList, 0, sortedList.Count - 1, nMin, currList)); // do it in a separated thread
            return sortedList;
        }
        private static void Sort(List<string> list, int left, int right, int nMin, string[] tmp)
        {
            if(left - right < nMin)
            {
                for (int i = left + 1; i <= right; i++)
                {
                    string key = list[i];
                    int j = i - 1;

                    while (j >= left && string.Compare(list[j], key) > 0)
                    {
                        list[j + 1] = list[j];
                        j--;
                    }

                    list[j + 1] = key;
                }
            }
            else
            {
                int mid = (left + right) / 2;
                Parallel.Invoke(
                      () => Sort(list, left, mid, nMin, tmp),
                      () => Sort(list, mid + 1, right, nMin, tmp));
                Merge(list, left, mid, nMin, tmp);
            }
        }
        private static void Merge(List<string> list, int left, int mid, int right, string[] tmp)
        {
            int i = left;
            int j = mid + 1;
            int k = 0;

            while (i <= mid && j <= right)
            {
                if (string.Compare(list[i], list[j]) <= 0)
                {
                    tmp[k++] = list[i++];
                }
                else
                {
                    tmp[k++] = list[j++];
                }
            }

            while (i <= mid)
            {
                tmp[k++] = list[i++];
            }

            while (j <= right)
            {
                tmp[k++] = list[j++];
            }

            for (i = 0; i < k; i++)
            {
                list[left + i] = tmp[i];
            }
    }


    }
}
