#include <iostream>

using namespace std;

class Student
{
private:
	string _name;
	int _age;
	int _grade;

public:
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

int global = 100;

int SetScore (int value)
	{
	static int score = 0; // 로컬변숰(지역변수), 정적변수
	global = 1000;
	score += value;

	return score;
	}

//동적객체
//변수의 종류
//접근범위, 존속기간

int main()
{
	int a; // 로컬변수(지역변수), 자동변수
	a = 20;
	global = 1000000;

	int* pa = new int;

	*pa = 1000; //포인터 연산자, 주소값에 할당받은 공간에 접속할때

	cout << "*pa=" << *pa << endl;

	delete pa; //동적메모리 공간을 반환처리

	

	return 0;
}