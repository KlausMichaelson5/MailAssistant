using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace MailAssistant.Helpers.KernelFunction
{
    /// <summary>
    /// Provides functions for drafting different parts of an email.
    /// </summary>
    public class EmailDraftingPlugin
    {
        /// <summary>
        /// Generates a greeting for the email based on the recipient's name and the time of day.
        /// </summary>
        /// <param name="recipientName">The name of the email recipient.</param>
        /// <returns>A greeting string.</returns>
        [KernelFunction("generate_greeting")]
        [Description("Generates a greeting for the email based on the recipient's name and the time of day.")]
        public async Task<string> GenerateGreeting(string recipientName)
        {
            string greeting = string.Empty;
            var currentTime = DateTime.Now.TimeOfDay;

            if (currentTime < TimeSpan.FromHours(12))
            {
                greeting = "Good morning";
            }
            else if (currentTime < TimeSpan.FromHours(18))
            {
                greeting = "Good afternoon";
            }
            else
            {
                greeting = "Good evening";
            }

            return await Task.FromResult($"{greeting}, {recipientName}");
        }


        /// <summary>
        /// Generates the body of the email based on the provided context and purpose.
        /// </summary>
        /// <param name="context">The context of the email.</param>
        /// <param name="purpose">The purpose of the email.</param>
        /// <returns>The body of the email.</returns>
        [KernelFunction("generate_body")]
        [Description("Generates the body of the email based on the provided context and purpose.")]
        public async Task<string> GenerateBody(string context, string purpose)
        {
            return await Task.FromResult($"I hope this message finds you well. I am writing to {purpose}. {context}");
        }

        /// <summary>
        /// Generates a closing for the email based on the sender's name and title.
        /// </summary>
        /// <param name="senderName">The name of the email sender.</param>
        /// <param name="senderTitle">The title of the email sender.</param>
        /// <returns>A closing string.</returns>
        [KernelFunction("generate_closing")]
        [Description("Generates a closing for the email based on the sender's name and title.")]
        public async Task<string> GenerateClosing(string senderName, string senderTitle)
        {
            return await Task.FromResult($"Best regards,\n{senderName}\n{senderTitle}");
        }

        /// <summary>
        /// Drafts a complete email with greeting, body, and closing.
        /// </summary>
        /// <param name="recipientName">The name of the email recipient.</param>
        /// <param name="context">The context of the email.</param>
        /// <param name="purpose">The purpose of the email.</param>
        /// <param name="senderName">The name of the email sender.</param>
        /// <param name="senderTitle">The title of the email sender.</param>
        /// <returns>A complete email draft.</returns>
        [KernelFunction("draft_email")]
        [Description("Drafts a complete email with greeting, body, and closing.")]
        public async Task<string> DraftEmail(string recipientName, string context, string purpose, string senderName, string senderTitle)
        {
            var greeting = GenerateGreeting(recipientName);
            var body = GenerateBody(context, purpose);
            var closing = GenerateClosing(senderName, senderTitle);

            return await Task.FromResult($"{greeting},\n\n{body}\n\n{closing}");
        }
    }
}