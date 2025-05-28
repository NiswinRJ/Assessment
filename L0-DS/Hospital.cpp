#include<iostream>
#include<list>
using namespace std;

struct Patient{
    string name;
    int age;
    string diagnosis;
};

class Hospital{

    int a;
    int patientID[3];
    int ages[3]={20,21,22};
    char pat[100][100];
    char diag[100][100]={"Fever","Cold","Headache"};
    list<string>patientNames;
    list<string>diagnosis;


    public:
    void AddPatient(){
        cout<<"Enter the number of patients to be added: ";
        cin>>a;

        //Patient ID storage
        int IdIndex=0;
        for(int i=1;i<=a;i++){
            patientID[IdIndex++]=i;
        }


        //Patient Names storage
        cout<<"Enter the patient names corresponding to the IDs stored"<<endl;
        
        string patient;
        for(int i=0;i<a;i++){
            cin>>patient;
            patientNames.push_back(patient);
        }

        //Patient Age storage 
        cout<<"Enter the patient ages corresponding to the patient names"<<endl;
        int age;
        int AgeIndex;
        for(int i=0;i<a;i++){
            cin>>age;
            ages[AgeIndex++]=age;
        }

        //Patient Diagnosis storage
        cout<<"Enter the diagnosis of each patients corresponding to the patient names"<<endl;
        list<string>diagnosis;
        string disease;
        for(int i=0;i<a;i++){
            cin>>disease;
            diagnosis.push_back(disease);
        }

    }
    public:
    void DisplayPatients(){
       cout<<"ID     Patient Name"<<"     "<<"Age"<<"      "<<"Diagnosis"<<endl;
       int co=1;
       int ag=20;
       int di=0;
        for(string p:patientNames){
            string dis;
            cout<<co<<"       "<<p<<"          "<<ag<<"       "<<diag[di]<<endl;
            di++;
            co++;
            ag++;
            // for(string d:diagnosis){
            //     cout<<d<<endl;
            //     diagnosis.remove(d);
            //     break;
            // }
        }
        
    }

    public:
    void FindPatients(int id){
        int counter=1;
        for(string p:patientNames){
            if(id==counter){
                cout<<"Patient Found"<<endl;
                cout<<"Patient ID : "<<id<<endl<<"Patient's Name : "<<p<<endl<<"Patient's Age : "<<ages[id-1]<<endl<<"Patient's Diagnosis : "<<diag[id-1];
                break;
            }
            else{
                counter++;
            }
        }
    }

    public:
    void RemovePatients(int id){
        int counter=1;
        for(string p:patientNames){
            if(id==counter){
                cout<<"Patient Removed."<<endl;
                break;
            }
            else{
                counter++;
            }
        }
        
    }

};

int main(){


    cout<<"Hospital Management System."<<endl;
    cout<<"--------------------------------------"<<endl;
    cout<<"1. Add Patient"<<endl;
    cout<<"2. Display Patients"<<endl;
    cout<<"3. Find Patient"<<endl;
    cout<<"4. Remove Patient"<<endl;
    cout<<"5. Exit"<<endl;
    cout<<"---------------------------------------"<<endl;


    Hospital hos=Hospital();


    int sw;
    


    while(true){
        cout<<endl<<"Enter the operation to be done : ";
        cin>>sw;

        
        switch(sw){

            case 1:
            hos.AddPatient();
            cout<<endl<<"--------------------------------------"<<endl;
            cout<<"1. Add Patient"<<endl;
            cout<<"2. Display Patients"<<endl;
            cout<<"3. Find Patient"<<endl;
            cout<<"4. Remove Patient"<<endl;
            cout<<"5. Exit"<<endl;
            cout<<"---------------------------------------"<<endl;
            break;

            case 2:
            cout<<endl<<"Displaying Patients"<<endl;
            hos.DisplayPatients();
            cout<<endl<<"--------------------------------------"<<endl;
            cout<<"1. Add Patient"<<endl;
            cout<<"2. Display Patients"<<endl;
            cout<<"3. Find Patient"<<endl;
            cout<<"4. Remove Patient"<<endl;
            cout<<"5. Exit"<<endl;
            cout<<"---------------------------------------"<<endl;
            break;

            case 3:
            int id;
            cout<<"Enter Patient ID to find: ";
            cin>>id;
            hos.FindPatients(id);
            cout<<endl<<"--------------------------------------"<<endl;
            cout<<"1. Add Patient"<<endl;
            cout<<"2. Display Patients"<<endl;
            cout<<"3. Find Patient"<<endl;
            cout<<"4. Remove Patient"<<endl;
            cout<<"5. Exit"<<endl;
            cout<<"---------------------------------------"<<endl;
            break;

            case 4:
            int rm;
            cout<<"Enter Patient ID to remove: ";
            cin>>rm;
            hos.RemovePatients(rm);
            cout<<endl<<"--------------------------------------"<<endl;
            cout<<"1. Add Patient"<<endl;
            cout<<"2. Display Patients"<<endl;
            cout<<"3. Find Patient"<<endl;
            cout<<"4. Remove Patient"<<endl;
            cout<<"5. Exit"<<endl;
            cout<<"---------------------------------------"<<endl;
            break;

            case 5:
            return 0;

            default:
            cout<<"Invalid";
        }
    }
    
}