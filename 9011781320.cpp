//Elikplim Yaa Anumu
//9011781320

#include <iostream>

using namespace std;

int main()
{
    char Fname[50];
    char Lname[50];
    float Fscore;
    float Sscore;
    float Tscore;
    float average;


    cout<< "Enter first name: ";
    cin>>Fname;
    cout<< "Enter Second name: ";
    cin>>Lname;
    cout << " \n";
    cout<< "Enter First score: ";
    cin>>Fscore;
    cout << "Enter second score: ";
    cin>>Sscore;
    cout<< "Enter third score: ";
    cin>>Tscore;
    cout<< "\n";
    if(Fscore<=75)
    {
        cout<< "You failed in your first test"<<endl;
    }
    else
    {
        cout<< "You passed in your first test"<<endl;
    }
    cout<< "\n";
    if (Sscore<=75)
    {
        cout<< "You failed in your second test"<<endl;
    }
    else
    {
        cout<< "You passed in your second test"<<endl;
    }
    cout<< "\n";
    if (Tscore<=75)
    {
        cout << "You failed in your third test"<<endl;

    }
    else
    {
        cout<< "You passed in your third test"<< endl;
    }
    cout<< "\n";

    average=(Fscore+Sscore+Tscore)/3;
    cout<< "Average: ";
    cout<<average<<endl;
    if (average>=80)
    {
        cout<<Fname; cout<< " "; cout<<Lname; cout<< " has been selected. A selection letter must be sent to him/her";
    }
    else
    {
        cout<<Fname; cout<< " "; cout<<Lname; cout<< " has been rejected. A rejection letter must be sent to him/her";
    }
    return 0;
}
