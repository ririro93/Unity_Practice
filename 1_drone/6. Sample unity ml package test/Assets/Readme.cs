﻿/* 
얘는 일단 
n_state_space = 1 인 겁나 간단하게 만든거.
	player.transform.position.x 이거 하나만 넣었더니 학습이 거의 안되는거 같음
	이유: 공이 떨어지는 위치가 랜덤이라서 그 시작 좌표도 state중 하나로 넣어주면 더 잘되지 않을까
	발전: 공이 일정한 시간간격으로 일정한 위치에서 떨어지게 해보면 학습되지않을까
		  지금 TestAgent애서 movement 변수가 무한대로 갈 수 있게 되어있음
    궁금한 점: 카메라로 observation 결과도 넣어주는데, 여러 각도 카메라 몇 개를 설치하면 그나마 될려나
			  카메라보다 state에 의존도가 훨씬 높은건가, 아니면 그 정도를 조절할 수 있나
<update 12/06 13:15>
n_state_space = 2 로 바꿈. obstable의 x 좌표값도 하나 추가
-> 조금 학습 되기 시작하는듯 그래도 episode 지날수록 계속 좋아지지느 않음	
-> hyperparameter 수정: learning_rate=3e-4에서 1e-4로 낮추니까 reward증가가 좀 안정적으로 보임		  
*/

