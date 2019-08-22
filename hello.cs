using System;
namespace HelloWorld
{
    class Hello
    {
        static void Main()
        {

          Console.WriteLine("******************************");
          Console.WriteLine("Welcom to the Minesweeper Game");

          Console.WriteLine("Plese enter Y for the rules");
          char ruels = char.Parse(Console.ReadLine());

          if(ruels == 'y'){
            Console.WriteLine(" ");
            Console.WriteLine("A squares neighbours are the squares adjacent above, below, left, right, and all 4 diagonals.");
            Console.WriteLine("Squares on the sides of the board or in a corner have fewer neighbors");
            Console.WriteLine("If you guess squares with 0 than its all neighbors are safe");
            Console.WriteLine("If you guess squares with 1 than one of its neighbors contain bomb");
            Console.WriteLine("If you guess squares with 2 than at least two of its neighbors contain bomb");
            Console.WriteLine("If you guess squares with 3 than at least three of its neighbors contain bomb");
            Console.WriteLine("So your goal is to guess all the squares without bomb\n");
            Console.WriteLine("E.g. row#-> 10 col#-> 10\n");
            Console.WriteLine("1*101*101* \n" +
                              "1221111011 \n" +
                              "01*2111110 \n" +
                              "0123*11*10 \n" +
                              "112*212220 \n" +
                              "2*42201*10 \n" +
                              "2*3*101121 \n" +
                              "112111111* \n" +
                              "000001*122 \n" +
                              "000001111* \n");
          }

          Console.WriteLine(" ");
          Console.WriteLine("Enter the number of row & Col");
          Console.WriteLine("to build the board");
          Console.WriteLine("E.g. row#-> 3 col#-> 3");
          Console.WriteLine(" ");
          Console.WriteLine("111");
          Console.WriteLine("1*1");
          Console.WriteLine("111");
          Console.WriteLine(" ");

          while(true){
          int row = 0;        //number of row
          int col = 0;        //number of column

            Console.WriteLine("Please Enter the number of Row: ");
            row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter the number of Col: ");
            col = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Now start gussing by entering row# and col# ");
            Console.WriteLine(" ");

            int[ , ] set = new int[row, col];     //initializing 2d array of row-y and col-x

            Console.WriteLine("Please Enter the Row: ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter the Col: ");
            int x = Convert.ToInt32(Console.ReadLine());

              Random rand = new Random();
              int randNum  = rand.Next((row+col)/2, row+col);

              for(int n = 0; n < randNum; n++){
                int randRow  = rand.Next(0, row);
                int randCol  = rand.Next(0, col);
                if(x-1 == randCol && y-1 == randRow){
                  n--;
                  continue;
                }
                set[randRow, randCol] = -1;
              }

            for (int j = 0; j < row; j++){
              for(int i = 0; i < col; i++){

                if(set[j, i] == -1){
                  if(i != 0){
                    if(j != 0){
                      if(set[j-1, i-1] != -1){set[j-1, i-1]  += 1;}
                    }
                    if(set[j, i-1] != -1){set[j, i-1] += 1;}
                    if(j != row-1){
                      if(set[j+1, i-1] != -1){set[j+1, i-1]  += 1; }
                    }
                  }
                  if(j != 0){
                    if(set[j-1, i] != -1){set[j-1, i] += 1;}
                    if(i != col-1){
                      if(set[j-1, i+1] != -1){set[j-1, i+1]  += 1;}
                    }
                  }
                  if(j != row-1){
                    if(set[j+1, i] != -1){set[j+1, i]    += 1;}
                    if(i != col-1){
                      if(set[j+1, i+1] != -1){set[j+1, i+1]  += 1;}
                    }
                  }
                  if(i != col-1){
                     if(set[j, i+1] != -1){set[j, i+1] += 1;}
                   }
                }
              }
          }
          for(int c = 0; c < row; c++){
            for(int d = 0; d < col; d++){
              if(set[c, d] == -1){
                Console.Write('*');
              }
              else{
                Console.Write(set[c, d]);
              }
            }
            Console.WriteLine(" ");
          }
          Console.WriteLine(" ");

          int[ , ] board = new int[row, col];
          for(int s = 0; s < row; s++){
            for(int r = 0; r < col; r++){
              board[s,r] = -1;
            }
          }

          int count = 1;
          while(true){
            if(count != 1){
              Console.WriteLine("Please Enter the Row: ");
              y = Convert.ToInt32(Console.ReadLine());
              Console.WriteLine("Please Enter the Col: ");
              x = Convert.ToInt32(Console.ReadLine());
            }
            if(set[y-1, x-1] == -1){
              Console.WriteLine(" Oops! wrong one");
              for(int a = 0; a < row; a++){
                for(int b = 0; b < col; b++){
                  if(set[a, b] == -1){
                    Console.Write('*');
                  }
                  else{
                    Console.Write(set[a, b]);
                  }
                }
                Console.WriteLine(" ");
              }
              Console.WriteLine(" ");
              break;
            }
            else{
              board[y-1, x-1] = set[y-1, x-1];
            }

            string result = new String('_', col+2);

            Console.WriteLine(result);
            for(int n = 0; n < row; n++){
              Console.Write('|');
              for(int m = 0; m < col; m++){
                if(board[n, m] == 0 || board[n, m] == 1 || board[n, m] == 2 || board[n, m] == 2 || board[n, m] == 4 ){
                  Console.Write(board[n, m]);
                }else{
                  Console.Write('.');
                }
              }
              Console.Write('|');
              Console.WriteLine(" ");
            }
            result = new String('-', col+2);
            Console.WriteLine( result );

            if(count == ((row * col) - randNum)){
              for(int a = 0; a < row; a++){
                for(int b = 0; b < col; b++){
                  if(set[a, b] == -1){
                    Console.Write('*');
                  }
                  else{
                    Console.Write(set[a, b]);
                  }
                }
                Console.WriteLine(" ");
              }
              Console.WriteLine(" ");
              Console.WriteLine("You WON!");
              break;
            }
            count++;
          }

            Console.WriteLine("Want to play again? [y/n]");
            char again = char.Parse(Console.ReadLine());
            if(again == 'n'){
              break;
            }
          }
        }
    }
}
