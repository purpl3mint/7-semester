#include <iostream>
#include <conio.h>
#include <stddef.h>
#include <fstream>

using namespace std;

uint8_t gencrc(uint8_t* data, size_t len)
{
	uint8_t crc = 0xff; // 0 FF
	size_t i, j;
	for (i = 0; i < len; i++) {
		crc ^= data[i];
		for (j = 0; j < 8; j++) {
			if ((crc & 0x80) != 0)
				crc = (uint8_t)((crc << 1) ^ 0x31);
			else
				crc <<= 1;
		}
	}
	return crc;
}

static unsigned char const crc8x_table[] = {
    0x00, 0x31, 0x62, 0x53, 0xc4, 0xf5, 0xa6, 0x97, 0xb9, 0x88, 0xdb, 0xea, 0x7d,
    0x4c, 0x1f, 0x2e, 0x43, 0x72, 0x21, 0x10, 0x87, 0xb6, 0xe5, 0xd4, 0xfa, 0xcb,
    0x98, 0xa9, 0x3e, 0x0f, 0x5c, 0x6d, 0x86, 0xb7, 0xe4, 0xd5, 0x42, 0x73, 0x20,
    0x11, 0x3f, 0x0e, 0x5d, 0x6c, 0xfb, 0xca, 0x99, 0xa8, 0xc5, 0xf4, 0xa7, 0x96,
    0x01, 0x30, 0x63, 0x52, 0x7c, 0x4d, 0x1e, 0x2f, 0xb8, 0x89, 0xda, 0xeb, 0x3d,
    0x0c, 0x5f, 0x6e, 0xf9, 0xc8, 0x9b, 0xaa, 0x84, 0xb5, 0xe6, 0xd7, 0x40, 0x71,
    0x22, 0x13, 0x7e, 0x4f, 0x1c, 0x2d, 0xba, 0x8b, 0xd8, 0xe9, 0xc7, 0xf6, 0xa5,
    0x94, 0x03, 0x32, 0x61, 0x50, 0xbb, 0x8a, 0xd9, 0xe8, 0x7f, 0x4e, 0x1d, 0x2c,
    0x02, 0x33, 0x60, 0x51, 0xc6, 0xf7, 0xa4, 0x95, 0xf8, 0xc9, 0x9a, 0xab, 0x3c,
    0x0d, 0x5e, 0x6f, 0x41, 0x70, 0x23, 0x12, 0x85, 0xb4, 0xe7, 0xd6, 0x7a, 0x4b,
    0x18, 0x29, 0xbe, 0x8f, 0xdc, 0xed, 0xc3, 0xf2, 0xa1, 0x90, 0x07, 0x36, 0x65,
    0x54, 0x39, 0x08, 0x5b, 0x6a, 0xfd, 0xcc, 0x9f, 0xae, 0x80, 0xb1, 0xe2, 0xd3,
    0x44, 0x75, 0x26, 0x17, 0xfc, 0xcd, 0x9e, 0xaf, 0x38, 0x09, 0x5a, 0x6b, 0x45,
    0x74, 0x27, 0x16, 0x81, 0xb0, 0xe3, 0xd2, 0xbf, 0x8e, 0xdd, 0xec, 0x7b, 0x4a,
    0x19, 0x28, 0x06, 0x37, 0x64, 0x55, 0xc2, 0xf3, 0xa0, 0x91, 0x47, 0x76, 0x25,
    0x14, 0x83, 0xb2, 0xe1, 0xd0, 0xfe, 0xcf, 0x9c, 0xad, 0x3a, 0x0b, 0x58, 0x69,
    0x04, 0x35, 0x66, 0x57, 0xc0, 0xf1, 0xa2, 0x93, 0xbd, 0x8c, 0xdf, 0xee, 0x79,
    0x48, 0x1b, 0x2a, 0xc1, 0xf0, 0xa3, 0x92, 0x05, 0x34, 0x67, 0x56, 0x78, 0x49,
    0x1a, 0x2b, 0xbc, 0x8d, 0xde, 0xef, 0x82, 0xb3, 0xe0, 0xd1, 0x46, 0x77, 0x24,
    0x15, 0x3b, 0x0a, 0x59, 0x68, 0xff, 0xce, 0x9d, 0xac };

unsigned crc8x_fast(uint8_t* mem, size_t len) {
	unsigned crc = 0xFF; // 0 FF
    if (mem == NULL)
        return 0xff;
    while (len--)
        crc = crc8x_table[crc ^ *mem++];
    return crc;
}

enum Option
{
	Exit = 3,
	Start = 0,
	First = 1,
	Second = 2
};

string dataInByte(int number)
{
	string s = "";
	int temp = 0x1;
	
	while (number)
	{
		s = ((number & temp)? "1" : "0") + s;
		number >>= 1;
	}

	return s;
}

int lengthNumber(int number)
{
	int length = 0;
	
	while (number) 
	{
		number >>= 1;
		length++;
	}

	return length;
}

	stringXor()
{


}
void directCRCalgorithm()
{
	uint8_t *data = NULL;
	uint8_t crc;
	
	data = (uint8_t*)malloc(sizeof(uint8_t));
	
	ifstream in("test.txt");
	
	int i = 0;

	if (in.is_open())
	{
		while (!in.eof())
		{
			in.read((char*)data + i, 1);
			i++;
			if (data != NULL)
				data = (uint8_t*)realloc(data, (i + 1) * sizeof(uint8_t));
		}

	}
	
	if (data != NULL)
		data[i-1] = '\0';
	
	crc = gencrc(data, i - 1);
	cout << "CRC код: " << (int)crc << "\n";
	cout << "CRC код: " << dataInByte(crc) <<"\n\n";

	string dataString = "";
	for (size_t j = 0; j < i; j++)
		dataString += dataInByte(data[j]);
	
	stringXor();

	int tempData = data;
	int tempK = startCRC;

	int lengthData;
	int lengthCRC;
	
	lengthData = lengthNumber(tempData);
	lengthCRC = lengthNumber(tempK);

	while (lengthData > lengthCRC)
	{
		tempK = startCRC;
		tempK <<= (lengthData - lengthCRC);

		tempData = (tempData xor tempK);

		lengthData = lengthNumber(tempData);
		lengthCRC = lengthNumber(tempK);
	}

	cout << "\nОстаток: " << dataInByte(tempData); ;
	cout << "\nОстаток: " << tempData << "\n"; ;
	
	
	
	free(data);

//	unsigned int startCRC = 0;
//	unsigned int CRC8 = 49; //const
//	unsigned int data = 0; //can change
//	unsigned int temp;
//	unsigned int tempData;
//	
//	cout << "Введите число: ";
//	cin >> data;
//	
//	//Пример 2
//	cout << "\nПрямой алгоритм вычисления (СRC-8)\n"
//		 << "Введите начальное значение CRC(0 или 255): ";
//	
//	cin >> startCRC;
//
//	while((startCRC != 0) && (startCRC != 255))
//	{
//		cout << "\nОшибка ввода\n"
//			<< "Введите начальное значение CRC(0 или 255): ";
//		
//		cin >> startCRC;
//	}
//
//	int dataExample2 = data;
//	for (int i = 0; i < 8; i++)
//	{
//		if (((startCRC & 0x1) xor (dataExample2 & 0x1)) == 1)
//		{
//			startCRC = startCRC xor CRC8;
//			startCRC = startCRC >> 1;
//			startCRC += 128;
//		}else {
//			startCRC = startCRC >> 1;
//		}
//		dataExample2 >>= 1;
//	}
//
//	cout << "\nCRC код: " << dataInByte(startCRC);
//	cout << "\nCRC код: "<<startCRC <<"\n";
//	//Конец примера 2
//	
//	tempData = data;
//	int tempK = startCRC;
//
//	int lengthData;
//	int lengthCRC;
//	
//	lengthData = lengthNumber(tempData);
//	lengthCRC = lengthNumber(tempK);
//
//	while (lengthData > lengthCRC)
//	{
//		tempK = startCRC;
//		tempK <<= (lengthData - lengthCRC);
//
//		tempData = (tempData xor tempK);
//
//		lengthData = lengthNumber(tempData);
//		lengthCRC = lengthNumber(tempK);
//	}
//
//	cout << "\nОстаток: " << dataInByte(tempData); ;
//	cout << "\nОстаток: " << tempData << "\n"; ;
//
//	
//	
//	cout << "\nВходные данные: " << dataInByte(data);
//	cout << "\nВходные данные: " << data << "\n";
//	
//	int endData = data;
//	endData <<= lengthNumber(tempData);
//	endData += tempData;
//
//	cout << "\nОтвет: " << dataInByte(endData);
//	cout << "\nОтвет: " << endData << "\n\n";
}

void tabularCRCmethod()
{
	/*static int datat;
	static int startCRC = 0;
	cout << "Введите данные: ";
	cin >> datat;
	
	cout << "\nВведите начальное значение CRC(0 или 255): ";
	cin >> startCRC;
	unsigned int test = crc8x_fast(startCRC, &datat, 1);
	cout << "\n" << test << "\n";
	cout << "Входные данные: " << dataInByte(test) << "\n\n";*/

	uint8_t* data = NULL;

	data = (uint8_t*)malloc(sizeof(uint8_t));

	ifstream in("test.txt");

	int i = 0;

	if (in.is_open())
	{
		while (!in.eof())
		{
			in.read((char*)data + i, 1);
			i++;
			if (data != NULL)
				data = (uint8_t*)realloc(data, (i + 1) * sizeof(uint8_t));
		}

	}

	if (data != NULL)
		data[i - 1] = '\0';

	unsigned int test = crc8x_fast(data, i - 1);

	cout << "CRC код: " << (int)test << "\n";
	cout << "CRC код: " << dataInByte(test) << "\n\n";



	free(data);
}

void menu()
{
	int choice = Start;

	while (choice != Exit)
	{
		cout << "Меню\n"
			 << "1. Прямой алгоритм вычисления CRC на основе примера 2\n"
			 << "2. Табличный алгоритм вычисления CRC\n"
			 << "3. Выход\n"
			 << "Ввод: ";
		
		cin >> choice;
		
		switch (choice)
		{
		case First:  system("cls"); 
					 directCRCalgorithm();
			break;
		case Second: system("cls"); 
					 tabularCRCmethod();
			break;
		default:
			break;
		}
	}
}

int main()
{
	setlocale(LC_ALL, "Russian");
	menu();
	return 0;
}