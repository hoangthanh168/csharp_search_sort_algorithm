using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2
{
    internal class SearchLib
    {


        public static int LinearSearch(int[] arr, int x)
        {
            // Duyệt qua từng phần tử trong mảng một cách tuần tự.
            for (int i = 0; i < arr.Length; i++)
            {
                // Nếu tìm thấy phần tử x trong mảng, trả về chỉ mục của nó.
                if (arr[i] == x)
                    return i;
            }
            // Nếu không tìm thấy phần tử x, trả về -1.
            return -1;
        }

        public static int BinarySearch(int[] arr, int x)
        {
            // Khởi tạo chỉ mục bên trái và phải của mảng.
            int left = 0, right = arr.Length - 1;

            // Tiếp tục tìm kiếm khi phần tử còn lại trong khoảng cần tìm.
            while (left <= right)
            {
                // Tính chỉ mục giữa của khoảng tìm kiếm.
                int mid = left + (right - left) / 2;

                // Nếu tìm thấy x, trả về chỉ mục của nó.
                if (arr[mid] == x)
                    return mid;

                // Nếu phần tử giữa nhỏ hơn x, hẹp khoảng tìm kiếm về bên phải.
                if (arr[mid] < x)
                    left = mid + 1;
                // Ngược lại, hẹp khoảng tìm kiếm về bên trái.
                else
                    right = mid - 1;
            }
            // Nếu không tìm thấy x, trả về -1.
            return -1;
        }

        public static int InterpolationSearch(int[] arr, int x)
        {
            int low = 0, high = arr.Length - 1;

            // Tiếp tục tìm kiếm khi x nằm trong khoảng giữa low và high.
            while (low <= high && x >= arr[low] && x <= arr[high])
            {
                // Nếu chỉ có một phần tử còn lại trong khoảng.
                if (low == high)
                {
                    if (arr[low] == x) return low;
                    return -1;
                }

                // Tính toán vị trí dự đoán dựa trên giá trị x và các giá trị ở ranh giới.
                int pos = low + (((high - low) / (arr[high] - arr[low])) * (x - arr[low]));

                // So sánh phần tử tại vị trí dự đoán với x.
                if (arr[pos] == x)
                    return pos;

                // Nếu phần tử tại vị trí dự đoán nhỏ hơn x, di chuyển sang bên phải.
                if (arr[pos] < x)
                    low = pos + 1;
                // Ngược lại, di chuyển sang bên trái.
                else
                    high = pos - 1;
            }
            // Nếu không tìm thấy x, trả về -1.
            return -1;
        }

    }
}
