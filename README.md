# 만나: 고령자 하체 근력 강화 운동 프로그램

[만나 Notion 페이지](https://www.notion.so/129bd5a6b5e3429a9b5695c9ed1b663a)

---

## 🖋 Content

- **한줄 설명**: 사용자에게 맞는 난이도로 운동 동작을 제시하여 사용자의 근력 향상을 이루는 것이 목표
- **기간**: 2017.03 - 2017.12
- **팀원**: 4명 (기획 2명/디자인 1명/개발 1명)
- **역할**: 프로그램 전체 개발
- **🏆 수상 내역**

    > 2017년 한국정보통신학회 우수논문상

    ![IMG_0894](https://user-images.githubusercontent.com/30456206/103285630-08af9400-4a22-11eb-9844-ddefdb594af1.jpeg)

    'Kinect 센서를 활용하는 노인 하체 근력 강화 시스템 연구` 논문에 제1저자로 참여

    - [한국정보통신학회 발표](https://github.com/wonhee009/Manna/blob/master/정보통신학회%20발표%20최종.pdf)
    - [한국정보통신학회논문지: Kinect 센서를 활용하는 노인 하체 근력 강화 시스템 연구 1저자](https://github.com/wonhee009/Manna/blob/master/A_Study_on_the_Lower_Body_Muscle_Stren··.pdf)

    ---

    > 만수무강나들이(만나) SW 저작권 출원 (2017.12.27)

    'Kinect 센서를 이용한 노인 하체 근력 강화 프로그램' SW 저작권 출원

    ---

    > 제2회 Pfizer Essential Health 디지털 오픈 이노베이션 은상

    ![IMG_0490](https://user-images.githubusercontent.com/30456206/103285669-241a9f00-4a22-11eb-9e89-e72758cb5608.jpeg)

    'Kinect 센서를 이용한 노인 하체 근력 강화 프로그램' 고도화한 후 참여

    한국 화이자제약에서 주최한 실버 헬스케어 솔루션 발굴 공모전에서 수상

## 🛠 Stack

- C#
- Unity
- Kinect

## 📖 수행 역할

- 고령자에게 치명적인 낙상을 예방하기 위해 하체 근력 홈트레이닝 콘텐츠 제공
- 사용자에게 맞춤 난이도로 운동 동작 제시
- Kinect로 사용자 관절 data 취득 후 내부 알고리즘을 통해 운동 여부 및 정확도 판단
- 3D로 제작된 가상의 트레이너를 제공해 사용자의 운동 정확도에 따라 음성 제공
- 사용자 영상을 임의로 제작한 3D 배경화면에 실시간으로 합성 및 렌더링해 제공
- 📊 **프로그램 흐름도**

    ![Untitled](https://user-images.githubusercontent.com/30456206/103285725-43193100-4a22-11eb-816c-34763e29b989.png)

    [콘텐츠 흐름도]

    ![Untitled 1](https://user-images.githubusercontent.com/30456206/103285740-4ca29900-4a22-11eb-8fae-2be6f4bda530.png)

    [시스템 흐름도]

## 🧰 주요 기능

`만나`의 주요 기능 두가지에 대해서 다룹니다.

### 운동 동작 판단 기능

- Kinect를 통해 입력 받은 관절 data 중 **위치 데이터 사용**
- 실시간으로 입력되는 값의 편차를 줄여 data 신뢰성을 높이기 위해 데이터 노이즈를 제거하는 **칼만 필터** 사용
- 재가공된 관절 data로 관절 사이 벡터 생성 후 내적을 이용해 **관절 사이의 각도** 산출
- 관절 사이의 각도와 관절 사이의 상대 거리를 통해 운동 여부 판단

---

### 영상 합성 기능

- Kinect를 통해 인식한 Sensor data를 사용 (Kinect 센서와 대상간의 거리 data)
- 관절에서부터 범위를 넓혀가며 Kinect와의 거리가 급변하는 점을 기준으로 영상에서 사용자를 크로마키
- Unity는 하늘을 렌더링하는 Main Camera와
- 사용자 Object에 크로마키된 사용자 영상 실시간 렌더링

![Untitled 2](https://user-images.githubusercontent.com/30456206/103285774-62b05980-4a22-11eb-9a36-f07deaa6a060.png)

[영상 합성 기능 모식도]

![Untitled 3](https://user-images.githubusercontent.com/30456206/103285796-6ba12b00-4a22-11eb-9e55-b2c8c5c6d53f.png)

[Unity Camera 배치]

![Untitled 4](https://user-images.githubusercontent.com/30456206/103285819-75c32980-4a22-11eb-9de3-9574bf4d77e3.png)

[렌더링 화면]
