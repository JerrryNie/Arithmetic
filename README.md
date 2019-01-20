# 四则运算生成系统命令行程序部分
* bin文件夹下的cal-cmd.exe文件可以直接运行。<br>
* 程序运行平台为Windows10 64bit，无需VS环境依赖<br>
* 全部源代码都在Arithmetic/cal-cmd/cal-cmd/路径下的Program.cs文件中
## 控制台应用程序使用说明
1.生成指定数量的题目使用命令"cal-cmd.exe -g num path powtype"，输出结果在指定路径中,如<br>
  ``cal-cmd.exe -g 100 problem.txt 1``<br>
  表示生成100道题目输出到problem.txt文件中，乘方采用"^"表示<br>
2.在命令行模式下做题使用命令"cal-cmd.exe -s num powtype"，如<br>
  ``cal-cmd.exe -s 10 0``<br>
  表示在命令行中做10道题，乘方采用"\*\*"表示<br>
3.对于乘方，0表示"\*\*"，1表示"^"
