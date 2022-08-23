#include <iostream>
#include <string>

using namespace std;
// Ư��ȭ
// �������� �ùķ��̼��� ����µ�
// ����, ��, ��, ����, 

class Animal {
protected:
    string _name;
    float _age;
    float _weight;
    float _height;

public:
    Animal(string name, float age, float weight, float height)
        : _name(name), _age(age), _weight(weight), _height(height) {}

    void Speak() {
        cout << _name << "�� ���մϴ�." << endl;
    }

    void Eat() {
        cout << _name << "�� �Խ��ϴ�." << endl;
    }

    void Run() {
        cout << _name << "�� �ݴϴ�." << endl;
    }

    void Info() {

        cout << "�̸�: " << _name << endl;
        cout << "����: " << _age << endl;
        cout << "������: " << _weight << endl;
        cout << "Ű: " << _height << endl;
    }

};

class Pig : public Animal {
public:
    Pig(string name, float age, float weight, float height)
        : Animal(name, age, weight, height) {}

    void Speak() {
        cout << _name << "�� �ܲ��մϴ�." << endl;
    }

};

class Cow : public Animal {
public:
    Cow(string name, float age, float weight, float height)
        : Animal(name, age, weight, height) {}

    void Speak() {
        cout << _name << "�� �����մϴ�." << endl;
    }

};

class Chicken : public Animal {
private:
    bool _isFly;

    void Fly() {
        cout << _name << "�� ���ϴ�." << endl;
    }

public:
    Chicken(string name, float age, float weight, float height, bool isFly)
        : Animal(name, age, weight, height), _isFly(isFly) {}

    void Speak() {
        cout << _name << "�� �������մϴ�." << endl;
    }

    void Run() {
        if (_isFly) {
            Fly();
        }
        else {
            cout << _name << "�� �ݴϴ�." << endl;
        }
    }

};

class Dolphin : public Animal {
private:
    void Swim() {
        cout << _name << "�� ���Ĩ�ϴ�." << endl;
    }
public:
    Dolphin(string name, float age, float weight, float height)
        : Animal(name, age, weight, height) {}

    void Speak() {
        cout << _name << "�� �����մϴ�." << endl;
    }

    void Run() {
        Swim();
    }
};

int main() {
    Cow cow("��", 1.2f, 230.0f, 1.8f);
    Pig pig("����", 1.2f, 230.0f, 1.8f);
    Chicken notFlyChicken("������ ��", 1.2f, 230.0f, 1.8f, false);
    Chicken FlyChicken("���� ��", 1.2f, 230.0f, 1.8f, true);
    Dolphin dolphin("����", 2.3f, 200.0f, 2.3f);

    cow.Speak();
    cow.Run();

    cout << endl;

    pig.Speak();
    pig.Run();

    cout << endl;

    notFlyChicken.Speak();
    notFlyChicken.Run();

    cout << endl;
    FlyChicken.Speak();
    FlyChicken.Run();

    cout << endl;
    dolphin.Speak();
    dolphin.Run();


    return 0;
}