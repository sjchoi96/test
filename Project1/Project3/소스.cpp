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

int SetScore(int value)
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
	

	int count = 0;
	cout << "�ʿ��� ���� �� ������ �Է��ϼ���: " << endl;
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