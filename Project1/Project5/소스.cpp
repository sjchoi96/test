#include <iostream>
#include <string>

using namespace std;

// 상속

// 동물 농장 시뮬레이션
// 돼지, 소, 닭

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
        cout << _name << "이 꿀꿀합니다. " << endl;
    }

    void Eat() {
        cout << _name << "이 먹습니다." << endl;
    }

    void Run() {
        cout << _name << "이 뜁니다. " << endl;
    }

    void info() {
        cout << "이름: " << _name << endl;
        cout << "나이: " << _age << endl;
        cout << "몸무게: " << _weight << endl;
        cout << "키: " << _height << endl;
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
        cout << _name << "이 음매합니다. " << endl;
    }

    void Eat() {
        cout << _name << "이 먹습니다." << endl;
    }

    void Run() {
        cout << _name << "이 뜁니다. " << endl;
    }

    void info() {
        cout << "이름: " << _name << endl;
        cout << "나이: " << _age << endl;
        cout << "몸무게: " << _weight << endl;
        cout << "키: " << _height << endl;
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
        cout << _name << "이 납니다." << endl;
    }

public:
    Chicken(string name, float age, float weight, float height, bool isFly)
        : _name(name), _age(age), _weight(weight), _height(height), _isFly(isFly) {}

    void Speak() {
        cout << _name << "이 꼬끼오 합니다." << endl;
    }

    void Eat() {
        cout << _name << "이 먹습니다." << endl;
    }

    void Run() {
        if (_isFly) {
            Fly();
        }
        else {
            cout << _name << "이 뜁니다." << endl;
        }
    }

    void info() {
        cout << "이름: " << _name << endl;
        cout << "나이: " << _age << endl;
        cout << "몸무게: " << _weight << endl;
        cout << "키: " << _height << endl;

        if (_isFly) {
            cout << "종류: 나는 닭" << endl;
        }
        else {
            cout << "종류: 못나는 닭" << endl;
        }
    }
};


int main() {

    Cow cow("소", 2.2f, 200.0f, 1.5f);
    Pig pig("돼지", 2.5f, 150.0f, 1.3f);
    Chicken flyChicken("나는닭", 0.5f, 2.5f, 0.3f, true);
    Chicken notFlyChicken("못나는닭", 0.5f, 2.5f, 0.3f, false);

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