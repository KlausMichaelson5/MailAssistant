using MailAssistant.BlazorWebApp.Helpers;

namespace MailAssistant.BlazorWebApp.Components.Pages
{
    /// <summary>
    /// Represents the review component for sharing email messages.
    /// </summary>
    public partial class Review
	{
        /// <summary>
        /// This will open outlook and copy the email into the body there.
        /// </summary>
        private async void ShareMessage()
        {
            if(emailToReview.EmailRecipient!=null)
            {
                await JSHelper.CallJavaScriptFunctionAsync(JS, "sendEmail", emailToReview.Email, emailToReview.EmailRecipient, emailToReview.EmailSubject);
            }
            await JSHelper.CallJavaScriptFunctionAsync(JS, "sendEmail", emailToReview.Email);
        }
	}
}