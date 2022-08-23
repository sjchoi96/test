#include <iostream>

using namespace std;

// C++������ ������ �Լ����� ����� �� �ִ�.
// ��ſ� �Ű������� ������ Ÿ���̳� ������ Ʋ�����մϴ�.
// C++ ������ �Լ� ���̹��ϴ� ������� ���� �ͱ۸�
// ���� �̸��� �Լ��� ����ϴ� ���� �����ε�(overloading) �̶�� �Ѵ�.


int add(int a, int b)
{
	return a + b;
}

float add(float a, float b)
{
	return a + b;
}

float add(float a, int b)
{
	return a + b;
}

float add(float a, float b, float c)
{
	return a + b + c;
}




int main() {

	int a = 20;
	int b = 30;
	float c = 1.2f;
	float d = 3.4f;

	int ret = add(a, b); 
	cout << a << "+" << b << "=" << ret << endl;

	float fret = add(c, d); 

	cout << c << "+" << d << "=" << fret << endl;


	return 0;
}