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
		cout << "�̸�:" << _name << endl;
		cout << "����:" << _age << endl;
		cout << "�г�:" << _grade << endl;
	}
};

int global = 100;

int SetScore (int value)
	{
	static int score = 0; // ���ú��H(��������), ��������
	global = 1000;
	score += value;

	return score;
	}

//������ü
//������ ����
//���ٹ���, ���ӱⰣ

int main()
{
	int a; // ���ú���(��������), �ڵ�����
	a = 20;
	global = 1000000;

	int* pa = new int;

	*pa = 1000; //������ ������, �ּҰ��� �Ҵ���� ������ �����Ҷ�

	cout << "*pa=" << *pa << endl;

	delete pa; //�����޸� ������ ��ȯó��

	

	return 0;
}