#include <iostream>
#include <string>

using namespace std;

// 상속의 장점
// 1. 기존의 클래스를 재사용
// 2. 공통되는 부분을 상위 클래스에 통합하여 반복을 제거하고 유지, 보수를 편리하게 합니다.
// 3. 공통되는 부모를 가지는 계층을 만들어서 다형성의 기본 구조를 제공한다.



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


//업캐스팅

int main()
{
	Parent a;
	Child b;
	a._value1 = 100;
	b._value1 = 300;
	b._value2 = 400;

	a = b;

	cout << "a._value1=" << a._value1 << endl;
	//부모의 데이타 타입에 자식의 데이타 타입을 대입할 수 있습니다.
	//업캐스팅

	//b = a;
	//자식데이타에 부모 데이타 타입은 대입할 수 없다
	//다운캐스팅

	Parent& refa = b;   // 업캐스팅

	cout << "refa._value1 = " << refa._value1 << endl;

	Child& refaa = (Child&)refa;   // 다운 캐스팅

	cout << "refaa._value1 = " << refaa._value1 << endl;
	cout << "refaa._value2 = " << refaa._value2 << endl;


	Parent* pa = &b;   // 업캐스팅
	pa->_value1 = 100;
	cout << "pa->_value1 = " << pa->_value1 << endl;

	Child* paa = (Child*)pa;   // 다운캐스팅
	cout << "paa->_value1 = " << paa->_value1 << endl;
	cout << "paa->_value2 = " << paa->_value2 << endl;


	return 0;
}