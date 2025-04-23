#include <iostream>

using namespace std;

int main()
{
    cout <<"C++ ARITHMETIC SOFTWARE" << endl;
    cout <<"^^^^^^^^^^^^^^^^^^^^^^^^^^^" <<endl;
    char Fname[50];
    char Lname[50];
    cout <<"Please enter your first name: ";
    cin>>Fname;
    cout<<"Please enter your last name: ";
    cin>>Lname; cout<<endl;
    int firstNumber;
    int secondNumber;
    cout<<"Please enter first number: ";
    cin>>firstNumber;
    cout<<"Please enter second number: ";
    cin>>secondNumber; cout<<endl;
    float Add;
    float Sub;
    float Div;
    float Mult;
    int Mod;
    int incrementFnum;
    int decrementFnum;
    int incrementSnum;
    int decrementSnum;

    Add=firstNumber+secondNumber;
    Sub=firstNumber-secondNumber;
    Div=firstNumber/secondNumber;
    Mult=firstNumber*secondNumber;
    Mod=firstNumber%secondNumber;
    incrementFnum=firstNumber;
    incrementFnum++;




    { cout<<firstNumber;  cout<<" + "; cout<<secondNumber; cout<<" = "; cout<<Add<<endl;}
    { cout<<firstNumber;  cout<<" - "; cout<<secondNumber; cout<<" = "; cout<<Sub<<endl;}
    { cout<<firstNumber;  cout<<" / "; cout<<secondNumber; cout<<" = "; cout<<Div<<endl;}
    { cout<<firstNumber;  cout<<" * "; cout<<secondNumber; cout<<" = "; cout<<Mult<<endl;}
    { cout<<firstNumber;  cout<<" % "; cout<<secondNumber; cout<<" = "; cout<<Mod<<endl;}
    cout<<endl;


    cout<<"Increment of first number: "; cout<<incrementFnum<<endl;
    decrementFnum=firstNumber;
    decrementFnum--;
    cout<<"Decrement of first number: "; cout<<decrementFnum<<endl;
    incrementSnum=secondNumber;
    incrementSnum++;
    cout<<"Increment of second number: "; cout<<incrementSnum<<endl;
    decrementSnum=secondNumber;
    decrementSnum--;

    cout<<"Decrement of second number: "; cout<<decrementSnum<<endl;
    cout<<endl;

    cout<<Fname; cout<<" "; cout<<Lname; cout<<", thank you for using my software. Bye!!";

    return 0;
}
