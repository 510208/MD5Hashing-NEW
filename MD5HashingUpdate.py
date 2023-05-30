import requests

# 請更換成您自己的Repository名稱和Owner名稱
repository = 'MD5Hashing-NEW'
owner = '510208'

# 設定API的URL和Header
url = f"https://api.github.com/repos/{owner}/{repository}/releases/latest"
headers = {
    'Accept': 'application/vnd.github.v3+json'
}

# 發送API請求
response = requests.get(url, headers=headers)

# 解析API回傳的JSON資料
if response.status_code == 200:
    release_data = response.json()
    latest_version = release_data['tag_name']
    changelog = release_data['body']
    print(f"最新版本號: {latest_version}")
    if changelog == "":
        changelog = "例行更新與修復錯誤"
    print(f"更新日誌:\n{changelog}")
else:
    print("無法取得最新版本資訊")
