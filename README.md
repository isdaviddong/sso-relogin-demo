# SSO 登入設定說明

本專案實作了純 JavaScript 的 SSO 登入功能，支援 Microsoft Account、Google 和 LINE 三種登入方式。

## 功能特色

- ✅ 純 JavaScript 實作，不依賴 ASP.NET Core OAuth middleware
- ✅ 支援三種 SSO 提供商：Microsoft Account、Google、LINE
- ✅ 統一的 callback 頁面顯示所有返回參數
- ✅ 安全的 state 參數驗證
- ✅ 從 appsettings.json 讀取設定
- ✅ 響應式設計，美觀的 UI

## 頁面結構

- `/` - 首頁，包含登入測試連結
- `/login` - SSO 登入頁面，包含三個登入按鈕
- `/callback` - 統一的 callback 頁面，顯示所有返回參數

## 設定各 SSO 提供商

### 1. Microsoft Account (Azure AD)

1. 前往 [Azure Portal](https://portal.azure.com/)
2. 導航至 **Azure Active Directory** > **App registrations**
3. 點擊 **New registration**
4. 設定應用程式：
   - Name: `SSO Test App`
   - Supported account types: `Accounts in any organizational directory and personal Microsoft accounts`
   - Redirect URI: `Web` - `https://localhost:7000/callback`
5. 註冊後，複製 **Application (client) ID**
6. 在 `appsettings.json` 中更新 `SSO:Microsoft:ClientId`

### 2. Google OAuth 2.0

1. 前往 [Google Cloud Console](https://console.cloud.google.com/)
2. 創建新專案或選擇現有專案
3. 啟用 **Google+ API** 和 **Google Identity API**
4. 導航至 **APIs & Services** > **Credentials**
5. 點擊 **Create Credentials** > **OAuth 2.0 Client IDs**
6. 設定應用程式：
   - Application type: `Web application`
   - Name: `SSO Test App`
   - Authorized redirect URIs: `https://localhost:7000/callback`
7. 複製 **Client ID**
8. 在 `appsettings.json` 中更新 `SSO:Google:ClientId`

### 3. LINE Login

1. 前往 [LINE Developers Console](https://developers.line.biz/console/)
2. 創建新的 Provider 或選擇現有的
3. 創建新的 Channel：
   - Channel type: `LINE Login`
   - Channel name: `SSO Test App`
4. 在 Channel 設定中：
   - Callback URL: `https://localhost:7000/callback`
   - 啟用需要的 scope：`profile`, `openid`, `email`
5. 複製 **Channel ID**
6. 在 `appsettings.json` 中更新 `SSO:LINE:ClientId`

## 設定檔案格式

更新 `appsettings.json` 和 `appsettings.Development.json`：

```json
{
  "SSO": {
    "Microsoft": {
      "ClientId": "your-actual-microsoft-client-id",
      "TenantId": "common",
      "RedirectUri": "https://localhost:7000/callback"
    },
    "Google": {
      "ClientId": "your-actual-google-client-id",
      "RedirectUri": "https://localhost:7000/callback"
    },
    "LINE": {
      "ClientId": "your-actual-line-client-id",
      "RedirectUri": "https://localhost:7000/callback"
    }
  }
}
```

## 本地開發設定

1. 確保應用程式在 HTTPS 上運行（SSO 要求）
2. 檢查 `Properties/launchSettings.json` 中的 URL 設定
3. 如果使用不同的 port，記得更新所有 SSO 提供商的 redirect URI

## 安全注意事項

1. **State 參數**：每次登入都會生成隨機的 state 參數，並在 callback 時驗證
2. **HTTPS 要求**：所有 SSO 提供商都要求使用 HTTPS
3. **Client Secret**：此實作為純前端，未使用 client secret（適用於 public client）

## 除錯資訊

- Callback 頁面會顯示所有返回的參數
- 包含 JSON 格式方便除錯
- 提供複製功能方便分析
- 顯示使用的登入提供商

## 執行方式

```bash
dotnet run
```

然後前往 `https://localhost:7000` 開始測試 SSO 登入功能。
