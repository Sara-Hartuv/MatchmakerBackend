﻿using Repository.Entities;
using Service.Interfaces;

public static class EmailTemplateHelper
{
    public static string GenerateMatchEmailBody(IMyDetails<Candidate> candidateService, Candidate receiver, Candidate proposedMatch, string callbackUrl)
    {
        return $@"
        <html>
        <head>
            <style>
                body {{
                    font-family: 'Arial', sans-serif;
                    background-color: #f9f9f9;
                    padding: 20px;
                    text-align: center;
                }}
                .container {{
                    max-width: 500px;
                    margin: auto;
                    background: #ffffff;
                    padding: 20px;
                    border-radius: 10px;
                    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                }}
                h2 {{
                    color: #2c3e50;
                }}
                p {{
                    font-size: 16px;
                    color: #34495e;
                    line-height: 1.5;
                }}
                .details {{
                    background: #ecf0f1;
                    padding: 10px;
                    border-radius: 8px;
                    margin: 15px 0;
                    font-size: 14px;
                    color: #2c3e50;
                }}
                .button {{
                    display: inline-block;
                    background-color: #3498db;
                    color: white;
                    padding: 12px 24px;
                    text-decoration: none;
                    font-size: 18px;
                    font-weight: bold;
                    border-radius: 5px;
                    margin-top: 20px;
                }}
                .button:hover {{
                    background-color: #2980b9;
                }}
                .footer {{
                    margin-top: 20px;
                    font-size: 12px;
                    color: #7f8c8d;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <h2>✨ יש לך התאמה חדשה! ✨</h2>
                <p>שלום {receiver.FirstName} {receiver.LastName},</p>
                <p>מצאנו עבורך התאמה פוטנציאלית!</p>
                
                <div class='details'>
                    <p><strong>פרטים על ההתאמה:</strong></p>
                    <p>{candidateService.GetGeneralCandidateInfo(proposedMatch)}</p>
                </div>

                <p>לחץ על הכפתור לקבלת פרטים נוספים:</p>
                <a class='button' href='{callbackUrl}'>🔍 אני מעוניין לקבל פרטים נוספים</a>

                <div class='footer'>
                    <p>💌 הודעה זו נשלחה אליך על ידי מערכת השידוכים שלנו.</p>
                    <p>אם קיבלת הודעה זו בטעות, אנא התעלם ממנה.</p>
                </div>
            </div>
        </body>
        </html>";
    }
}
