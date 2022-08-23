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
		cout << "�̸�:" << _name << endl;
		cout << "����:" << _age << endl;
		cout << "�г�:" << _grade << endl;
	}
};

int main()
{
	Student* pa = new Student("monster", 10, 3);// ������ü �Ҵ�

	pa->info(); //�ּҰ����� Ŭ������ ����� �����Ҷ��� ȭ��ǥ �����ڸ� ����մϴ�.

	



	delete pa; //������ü ��ȯ

	Student* parray = new Student[5]; // ������ü �迭 �⺻������

	for (int i = 0; i < 5; i++)
	{
		parray[i].Init("monster", i, i);
	}

	for (int i = 0; i < 5; i++)
	{
		parray[i].info();
	}

	delete[] parray; // ������ü �迭 �Ҵ� ����


	return 0;
}