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

int SetScore(int value)
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
	

	int count = 0;
	cout << "필요한 정수 의 갯수를 입력하세요: " << endl;
	cin >> count;

	int* parray = new int[count];

	for (int i = 0; i < count; i++)
	{
	parray[i] = i;
	}

	for (int i = 0; i < count; i++)
	{
		cout << "parray{" << i << "] = " << parray[i] << endl;
	}

		delete[] parray;

	return 0;
}