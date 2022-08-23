#include <iostream>
#include <string>

using namespace std;

class Student
{
private:
	string _name;
	int _age;
	int _grade;

public:
	Student() {};
	Student(string name, int age, int grade)
		: _name(name), _age(age), _grade(grade) {}

	void Init(string name, int age, int grade)
	{
		_name = name;
		_age = age;
		_grade = grade;
	}

	void info()
	{
		cout << "이름:" << _name << endl;
		cout << "나이:" << _age << endl;
		cout << "학년:" << _grade << endl;
	}
};

int main()
{
	Student* pa = new Student("monster", 10, 3);// 동적객체 할당

	pa->info(); //주소값으로 클래스의 멤버에 접글할때는 화살표 연산자를 사용합니다.

	



	delete pa; //동적객체 반환

	Student* parray = new Student[5]; // 동적객체 배열 기본생성자

	for (int i = 0; i < 5; i++)
	{
		parray[i].Init("monster", i, i);
	}

	for (int i = 0; i < 5; i++)
	{
		parray[i].info();
	}

	delete[] parray; // 동적객체 배열 할당 해제


	return 0;
}