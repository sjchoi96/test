#include <iostream>
#include <string>

using namespace std;

// ���

// ���� ���� �ùķ��̼�
// ����, ��, ��

class Pig {
private:
    string _name;
    float _age;
    float _weight;
    float _height;

public:
    Pig(string name, float age, float weight, float height)
        : _name(name), _age(age), _weight(weight), _height(height) {}

    void Speak() {
        cout << _name << "�� �ܲ��մϴ�. " << endl;
    }

    void Eat() {
        cout << _name << "�� �Խ��ϴ�." << endl;
    }

    void Run() {
        cout << _name << "�� �ݴϴ�. " << endl;
    }

    void info() {
        cout << "�̸�: " << _name << endl;
        cout << "����: " << _age << endl;
        cout << "������: " << _weight << endl;
        cout << "Ű: " << _height << endl;
    }
};

class Cow {
private:
    string _name;
    float _age;
    float _weight;
    float _height;

public:
    Cow(string name, float age, float weight, float height)
        : _name(name), _age(age), _weight(weight), _height(height) {}

    void Speak() {
        cout << _name << "�� �����մϴ�. " << endl;
    }

    void Eat() {
        cout << _name << "�� �Խ��ϴ�." << endl;
    }

    void Run() {
        cout << _name << "�� �ݴϴ�. " << endl;
    }

    void info() {
        cout << "�̸�: " << _name << endl;
        cout << "����: " << _age << endl;
        cout << "������: " << _weight << endl;
        cout << "Ű: " << _height << endl;
    }
};

class Chicken {
private:
    string _name;
    float _age;
    float _weight;
    float _height;
    bool _isFly;

    void Fly() {
        cout << _name << "�� ���ϴ�." << endl;
    }

public:
    Chicken(string name, float age, float weight, float height, bool isFly)
        : _name(name), _age(age), _weight(weight), _height(height), _isFly(isFly) {}

    void Speak() {
        cout << _name << "�� ������ �մϴ�." << endl;
    }

    void Eat() {
        cout << _name << "�� �Խ��ϴ�." << endl;
    }

    void Run() {
        if (_isFly) {
            Fly();
        }
        else {
            cout << _name << "�� �ݴϴ�." << endl;
        }
    }

    void info() {
        cout << "�̸�: " << _name << endl;
        cout << "����: " << _age << endl;
        cout << "������: " << _weight << endl;
        cout << "Ű: " << _height << endl;

        if (_isFly) {
            cout << "����: ���� ��" << endl;
        }
        else {
            cout << "����: ������ ��" << endl;
        }
    }
};


int main() {

    Cow cow("��", 2.2f, 200.0f, 1.5f);
    Pig pig("����", 2.5f, 150.0f, 1.3f);
    Chicken flyChicken("���´�", 0.5f, 2.5f, 0.3f, true);
    Chicken notFlyChicken("�����´�", 0.5f, 2.5f, 0.3f, false);

    cow.Speak();
    cow.Run();

    cout << endl;

    pig.Speak();
    pig.Run();

    cout << endl;

    flyChicken.Speak();
    flyChicken.Run();

    cout << endl;

    notFlyChicken.Speak();
    notFlyChicken.Run();


    return 0;
}