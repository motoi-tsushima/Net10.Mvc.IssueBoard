-- Created by GitHub Copilot in SSMS - review carefully before executing

-- Samples データベースの作成
CREATE DATABASE Samples;
GO

-- Samples データベースを使用
USE Samples;
GO

-- Issues テーブルの作成
CREATE TABLE Issues (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AuthorName NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    Category NVARCHAR(30) NULL,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(2000) NOT NULL,
    Status INT NOT NULL DEFAULT 0 CHECK (Status IN (0, 1, 2, 3, 4)),
    Resolution NVARCHAR(2000) NULL,
    ResolverName NVARCHAR(50) NULL,
    ResolvedAt DATETIME2 NULL
);
GO

-- Status カラムへのコメント追加（拡張プロパティとして）
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'0:未着手, 1:着手中, 2:解決失敗, 3:課題確認不能, 4:解決済み',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE', @level1name = 'Issues',
    @level2type = N'COLUMN', @level2name = 'Status';
GO