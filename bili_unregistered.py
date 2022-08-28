import requests
import json


def wirteN(type, text):
    f = open('./Report.txt', 'a+', encoding='utf8')
    f.write(type + ':\t' + str(text))
    f.write('\n')


nickNameFile_URL = './nickNameFile.txt'

with open(nickNameFile_URL, 'r', encoding='utf8') as f:
    line_read = f.read().splitlines()  # 去掉读取列里面的/n
    f.close()

for i in range(0, len(line_read)):
    nick_name = str(line_read[i])
    url = r"http://passport.bilibili.com/web/generic/check/nickname?nickName=" + nick_name
    print(url)
    page = requests.get(url)
    json1 = json.loads(page.text)
    print(json1)
    code = json1["code"]
    # list(json1.keys())[0]
    if code == 0:
        wirteN('可以使用', nick_name)
    else:
        try:
            wirteN(json1["message"], nick_name)
        except Exception as error:
            wirteN(str(error), nick_name)
