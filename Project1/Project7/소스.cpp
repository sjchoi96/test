#include <iostream>
#include <string>

using namespace std;

// ����� ����
// 1. ������ Ŭ������ ����
// 2. ����Ǵ� �κ��� ���� Ŭ������ �����Ͽ� �ݺ��� �����ϰ� ����, ������ ���ϰ� �մϴ�.
// 3. ����Ǵ� �θ� ������ ������ ���� �������� �⺻ ������ �����Ѵ�.



class Parent
{
public:
	int _value1;

};

class Child : public Parent
{
public:
	int _value2;
};


//��ĳ����

int main()
{
	Parent a;
	Child b;
	a._value1 = 100;
	b._value1 = 300;
	b._value2 = 400;

	a = b;

	cout << "a._value1=" << a._value1 << endl;
	//�θ��� ����Ÿ Ÿ�Կ� �ڽ��� ����Ÿ Ÿ���� ������ �� �ֽ��ϴ�.
	//��ĳ����

	//b = a;
	//�ڽĵ���Ÿ�� �θ� ����Ÿ Ÿ���� ������ �� ����
	//�ٿ�ĳ����

	Parent& refa = b;   // ��ĳ����

	cout << "refa._value1 = " << refa._value1 << endl;

	Child& refaa = (Child&)refa;   // �ٿ� ĳ����

	cout << "refaa._value1 = " << refaa._value1 << endl;
	cout << "refaa._value2 = " << refaa._value2 << endl;


	Parent* pa = &b;   // ��ĳ����
	pa->_value1 = 100;
	cout << "pa->_value1 = " << pa->_value1 << endl;

	Child* paa = (Child*)pa;   // �ٿ�ĳ����
	cout << "paa->_value1 = " << paa->_value1 << endl;
	cout << "paa->_value2 = " << paa->_value2 << endl;


	return 0;
}