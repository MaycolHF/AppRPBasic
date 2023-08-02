using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ingrese el array de números (por ejemplo, 2,7,11,15): ");
                    string input = Console.ReadLine();
                    int[] numbers = input.Split(',').Select(int.Parse).ToArray();

                    Console.Write("Ingrese el número objetivo (por ejemplo, 9): ");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out int target))
                    {
                        throw new ArgumentException("El número objetivo debe ser un número entero.");
                    }

                    int[] result = TwoSum(numbers, target);

                    Console.WriteLine(result is null ? "No se encontró una solución." : $"[{result[0]}, {result[1]}]");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error: Formato de número inválido. {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.Write("¿Desea salir? (Y/N): ");
                string response = Console.ReadLine();
                if (response.ToUpper() == "Y")
                {
                    break;
                }
            }
        }

        static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.TryGetValue(complement, out int index))
                {
                    return new int[] { index, i };
                }
                if (!dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]] = i;
                }
            }

            return null;
        }
    }
}
