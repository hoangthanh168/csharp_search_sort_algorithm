using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2
{
    internal class SortLib
    {
        public static void SelectionSort(int[] arr)
        {
            // Số lượng phần tử trong mảng
            int n = arr.Length;

            // Duyệt qua mỗi phần tử của mảng
            for (int i = 0; i < n - 1; i++)
            {
                // Giả định phần tử ở vị trí 'i' là phần tử nhỏ nhất
                int min_idx = i;

                // So sánh phần tử ở vị trí 'i' với các phần tử tiếp theo trong mảng
                for (int j = i + 1; j < n; j++)
                {
                    // Nếu tìm thấy phần tử nào nhỏ hơn phần tử tại 'min_idx', cập nhật 'min_idx'
                    if (arr[j] < arr[min_idx])
                        min_idx = j;
                }

                // Đổi chỗ phần tử nhỏ nhất tìm được với phần tử ở vị trí 'i'
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
        }


        public static void InsertionSort(int[] arr)
        {
            // Số lượng phần tử trong mảng
            int n = arr.Length;

            // Bắt đầu từ phần tử thứ hai (ở vị trí 1)
            for (int i = 1; i < n; ++i)
            {
                // Phần tử cần chèn vào vị trí thích hợp
                int key = arr[i];

                // Vị trí phần tử trước 'key'
                int j = i - 1;

                // Di chuyển các phần tử của arr[0..i-1] lớn hơn 'key'
                // lên một vị trí để tạo ra không gian cho 'key'
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                // Chèn 'key' vào vị trí thích hợp
                arr[j + 1] = key;
            }
        }


        //Thuật giải sắp xếp đổi chỗ trực tiếp (Interchange Sort):
        public static void InterchangeSort(int[] arr)
        {
            // Số lượng phần tử trong mảng
            int n = arr.Length;

            // Duyệt từ phần tử đầu tiên đến phần tử áp chót
            for (int i = 0; i < n - 1; i++)
            {
                // Duyệt từ phần tử kế tiếp của 'i' đến phần tử cuối cùng
                for (int j = i + 1; j < n; j++)
                {
                    // Nếu phần tử 'i' lớn hơn phần tử 'j'
                    if (arr[i] > arr[j])
                    {
                        // Đổi chỗ hai phần tử
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }


        public static void BubbleSort(int[] arr)
        {
            // Số lượng phần tử trong mảng
            int n = arr.Length;

            // Duyệt qua mỗi phần tử của mảng
            for (int i = 0; i < n - 1; i++)
            {
                // Duyệt mảng từ phần tử đầu đến n - i - 1
                // Lưu ý: mỗi lần duyệt sẽ "nổi" phần tử lớn nhất lên cuối
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Nếu phần tử hiện tại lớn hơn phần tử kế tiếp
                    if (arr[j] > arr[j + 1])
                    {
                        // Đổi chỗ hai phần tử
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }



        public static void Heapify(int[] arr, int n, int i)
        {
            int largest = i; // Khởi tạo lớn nhất là gốc
            int left = 2 * i + 1;  // trái = 2*i + 1
            int right = 2 * i + 2;  // phải = 2*i + 2

            // Nếu con trái của gốc lớn hơn gốc
            if (left < n && arr[left] > arr[largest])
                largest = left;

            // Nếu con phải của gốc lớn hơn gốc
            if (right < n && arr[right] > arr[largest])
                largest = right;

            // Nếu gốc không phải là lớn nhất
            if (largest != i)
            {
                // Đổi chỗ gốc và con lớn nhất
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Đệ quy vun đống phần tử gốc
                Heapify(arr, n, largest);
            }
        }

        public static void HeapSort(int[] arr)
        {
            int n = arr.Length;

            // Xây dựng đống ban đầu (rearrange array)
            // Bắt đầu từ nửa cuối của mảng vì nửa đầu chứa các node lá, không cần xử lý
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);

            // Một một trích xuất mỗi phần tử từ đống
            for (int i = n - 1; i >= 0; i--)
            {
                // Di chuyển gốc hiện tại (giá trị lớn nhất) tới cuối mảng
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // Vun đống lại với phần còn lại của mảng
                Heapify(arr, i, 0);
            }
        }



        //Thuật giải sắp xếp nhanh (Quick Sort):
        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // pi là chỉ số nơi phần tử này đã đặt đúng vị trí sau mỗi lần gọi hàm Partition
                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);  // sort phần tử trước vị trí pi
                QuickSort(arr, pi + 1, high); // sort phần tử sau vị trí pi
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            // Lấy phần tử cuối cùng làm giá trị pivot (có thể chọn cách khác để chọn pivot)
            int pivot = arr[high];

            // i là chỉ số của phần tử nhỏ hơn hoặc bằng pivot
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                // Nếu phần tử hiện tại nhỏ hơn pivot
                if (arr[j] < pivot)
                {
                    i++;  // tăng chỉ số của phần tử nhỏ hơn hoặc bằng pivot

                    // Đổi chỗ arr[i] và arr[j]
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // Đổi chỗ arr[i + 1] và arr[high] (hoặc pivot)
            int swapTemp = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = swapTemp;

            // Trả về vị trí phân chia
            return i + 1;
        }


        //Thuật giải sắp xếp trộn (Merge Sort):
        public static void MergeSort(int[] arr, int left, int right)
        {
            // Kiểm tra điều kiện cơ bản: left < right
            if (left < right)
            {
                // Tìm vị trí giữa của mảng
                int middle = (left + right) / 2;

                // Đệ quy cho nửa trái
                MergeSort(arr, left, middle);
                // Đệ quy cho nửa phải
                MergeSort(arr, middle + 1, right);

                // Trộn hai nửa đã sắp xếp
                Merge(arr, left, middle, right);
            }
        }

        private static void Merge(int[] arr, int left, int middle, int right)
        {
            // Tính kích thước của hai mảng con để trộn
            int n1 = middle - left + 1;
            int n2 = right - middle;

            // Tạo mảng tạm
            int[] L = new int[n1];
            int[] R = new int[n2];

            // Sao chép dữ liệu vào mảng tạm L[] và R[]
            for (int i = 0; i < n1; i++)
                L[i] = arr[left + i];
            for (int j = 0; j < n2; j++)
                R[j] = arr[middle + 1 + j];

            // Bắt đầu việc trộn
            int x = 0, y = 0;

            // Khởi tạo chỉ số bắt đầu của mảng con và mảng kết hợp
            int k = left;

            // Trộn hai mảng tạm vào mảng arr[]
            while (x < n1 && y < n2)
            {
                if (L[x] <= R[y])
                {
                    arr[k] = L[x];
                    x++;
                }
                else
                {
                    arr[k] = R[y];
                    y++;
                }
                k++;
            }

            // Sao chép các phần tử còn lại của L[], nếu có
            while (x < n1)
            {
                arr[k] = L[x];
                x++;
                k++;
            }

            // Sao chép các phần tử còn lại của R[], nếu có
            while (y < n2)
            {
                arr[k] = R[y];
                y++;
                k++;
            }
        }



        //Phương pháp sắp xếp theo cơ số (Radix Sort):
        public static void RadixSort(int[] arr)
        {
            // Tìm phần tử lớn nhất để biết số lượng chữ số cần xử lý
            int max = arr.Max();

            // Duyệt qua mỗi cơ số. exp là 10 mũ i, 
            // bắt đầu từ chữ số cuối cùng và di chuyển lên trên.
            for (int exp = 1; max / exp > 0; exp *= 10)
                CountSort(arr, exp);
        }

        private static void CountSort(int[] arr, int exp)
        {
            int n = arr.Length;
            int[] output = new int[n]; // Mảng tạm thời để lưu kết quả sắp xếp
            int[] count = new int[10]; // Có 10 số từ 0 đến 9

            // Khởi tạo mảng count với tất cả giá trị là 0
            for (int i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            // Thay đổi count[i] để count[i] giờ đây chứa số lượng 
            // phần tử có giá trị nhỏ hơn hoặc bằng i
            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Xây dựng mảng output
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Sao chép mảng output vào mảng arr ban đầu
            // để arr chứa kết quả sắp xếp
            for (int i = 0; i < n; i++)
                arr[i] = output[i];
        }

    }
}
