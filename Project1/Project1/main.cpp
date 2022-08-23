#include <iostream>

using namespace std;

// C++에서는 동일한 함수명을 사용할 수 있다.
// 대신에 매개변수의 데이터 타입이나 갯수가 틀려야합니다.
// C++ 에서는 함수 네이밍하는 방법으로 네임 맹글링
// 같은 이름의 함수를 사용하는 것을 오버로딩(overloading) 이라고 한다.


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