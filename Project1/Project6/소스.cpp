#include <iostream>
#include <string>

using namespace std;
// 특수화
// 동물농장 시뮬레이션을 만드는데
// 돼지, 소, 닭, 돌고래, 

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
        cout << _name << "이 말합니다." << endl;
    }

    void Eat() {
        cout << _name << "이 먹습니다." << endl;
    }

    void Run() {
        cout << _name << "이 뜁니다." << endl;
    }

    void Info() {

        cout << "이름: " << _name << endl;
        cout << "나이: " << _age << endl;
        cout << "몸무게: " << _weight << endl;
        cout << "키: " << _height << endl;
    }

};

class Pig : public Animal {
public:
    Pig(string name, float age, float weight, float height)
        : Animal(name, age, weight, height) {}

    void Speak() {
        cout << _name << "이 꿀꿀합니다." << endl;
    }

};

class Cow : public Animal {
public:
    Cow(string name, float age, float weight, float height)
        : Animal(name, age, weight, height) {}

    void Speak() {
        cout << _name << "이 음매합니다." << endl;
    }

};

class Chicken : public Animal {
private:
    bool _isFly;

    void Fly() {
        cout << _name << "이 납니다." << endl;
    }

public:
    Chicken(string name, float age, float weight, float height, bool isFly)
        : Animal(name, age, weight, height), _isFly(isFly) {}

    void Speak() {
        cout << _name << "이 꼬끼오합니다." << endl;
    }

    void Run() {
        if (_isFly) {
            Fly();
        }
        else {
            cout << _name << "이 뜁니다." << endl;
        }
    }

};

class Dolphin : public Animal {
private:
    void Swim() {
        cout << _name << "이 헤엄칩니다." << endl;
    }
public:
    Dolphin(string name, float age, float weight, float height)
        : Animal(name, age, weight, height) {}

    void Speak() {
        cout << _name << "이 끽끽합니다." << endl;
    }

    void Run() {
        Swim();
    }
};

int main() {
    Cow cow("소", 1.2f, 230.0f, 1.8f);
    Pig pig("돼지", 1.2f, 230.0f, 1.8f);
    Chicken notFlyChicken("못나는 닭", 1.2f, 230.0f, 1.8f, false);
    Chicken FlyChicken("나는 닭", 1.2f, 230.0f, 1.8f, true);
    Dolphin dolphin("돌고래", 2.3f, 200.0f, 2.3f);

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