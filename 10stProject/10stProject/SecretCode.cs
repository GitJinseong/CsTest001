using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// 컴퓨터가 숨기고 있는 비밀 코드를 추측하는 게임
// 컴퓨터는 비밀 코드를 하나 랜덤하게 선정한다.
// 1. 비밀 코드는 아스키 코드로 이루어져 있다.
// 2. 유저는 input 입력해서 비밀 코드가 어떤건지 추측한다.
// 3. 컴퓨터는 유저의 추측을 보고 비밀 코드가 앞에 있는지,
// 뒤에 있는지 알려준다.
// 4. 몇 번만에 맞추는지에 따라서 점수를 부여한다.
// 5. 유저가 코드를 맞추면 게임을 종료한다.
// [조건]
// a. 클래스를 활용해서 구현한다.
// ex) SecretCode myScretCode = new SecretCode();
//      mySecretCode.Play();

// 아스키 코드
// 0~31 , 32~63 , 64~95 , 96 127
namespace _10stProject
{

    public class SecretCode
    {
        private int secretNumber;
        private int wrongCount = 1;

        public void CreateSecretCode()
        {
            Random random = new Random();
            int randomValue = random.Next(0, 3);

            switch(randomValue)
            {
                case 0:
                    secretNumber = random.Next(0, 31);
                    break;

                case 1:
                    secretNumber = random.Next(32, 63);
                    break;

                case 2:
                    secretNumber = random.Next(64, 95);
                    break;

                case 3:
                    secretNumber = random.Next(96, 127);
                    break;
            }
        }

        public int InputValue()
        {
            Console.WriteLine("숫자를 입력해 맞추시오.(0~127)");
            Console.Write(" : ");

            int inputValue;
            int.TryParse(Console.ReadLine(), out inputValue);

            return inputValue;
        }

        public void CheckValue(int inputValue, out bool runWhile)
        {

            if (inputValue > secretNumber)
            {
                Console.WriteLine("입력하신 숫자는 비밀 코드보다 큽니다.\n");
                wrongCount++;
            }
            else if (inputValue == secretNumber)
            {
                Console.WriteLine("{0}번 만에, 비밀 코드를 맞추셨습니다.", wrongCount);
                Console.WriteLine("비밀 코드는 {0} 이었습니다.\n", secretNumber);
                runWhile = false;
            }
            else if (inputValue < secretNumber)
            {
                Console.WriteLine("입력하신 숫자는 비밀 코드보다 작습니다.\n");
                wrongCount++;
            }

            runWhile = true;
        }

        public void Play()
        {
            CreateSecretCode();

            Console.WriteLine("비밀 코드가 생성되었습니다.");

            bool runWhile = true;

            while (runWhile == true)
            {
                char asciiCode = (char)secretNumber;
                int inputValue;

                Console.WriteLine("비밀 코드는 {0} (정답:{1})입니다.\n", asciiCode, secretNumber); 

                inputValue = InputValue();

                CheckValue(inputValue, out runWhile);
            }

        }
    }
}
