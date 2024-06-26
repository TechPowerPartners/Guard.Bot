﻿using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace DC.Bot.DiscordApi.PrefixCommands;

internal class CoreCommands : BaseCommandModule
{
	[Command("help")]
	public async Task HelpCommand(CommandContext context)
	{
		var builder = new DiscordEmbedBuilder()
		   .WithTitle("Команды")
		   .WithDescription("Для того чтобы обращаться ко мне используй !guru <команда>")
		   .WithColor(DiscordColor.Gold)
		   .AddField("panel", "Панель управления")
		   .AddField("help-channels", "Обзор сервера");

		await context.RespondAsync(builder);
	}

	[Command("panel")]
	public async Task PanelCommand(CommandContext context)
	{
		var embedBuilder = new DiscordEmbedBuilder()
		   .WithTitle("Панель управления")
		   .WithColor(DiscordColor.Azure);

		List<DiscordComponent> firstRow =
		[
		   new DiscordButtonComponent(ButtonStyle.Success, "panel-create-personal-acc", "Создать учетную запись"),
		 new DiscordButtonComponent(ButtonStyle.Success, "panel-shedule-interview", "Назначить собеседование"),
	  ];

		var messageBuilder = new DiscordMessageBuilder()
		   .AddComponents(firstRow)
		   .AddEmbed(embedBuilder);

		var discordDmChannel = await context.Member.CreateDmChannelAsync();
		await discordDmChannel.SendMessageAsync(messageBuilder);
	}

	[Command("help-channels")]
	public async Task HelpChannelsCommand(CommandContext context)
	{
		var message = """
                    Краткий экскурс по нашему замечательному серверу!
                    'Общее' - Здесь ты можешь пообщаться с нашим дружным коллективом
                    'Ресурсы' - Кладезь интересной и полезной информации, сюда кидают тонну контента для программиста (от книг и статей до обучающих видео и сливов курсов)
                    'Хвастаемся и помогаем' - Кидай сюда свой код на ревью, его разберут, найдут ошибки, и подскажут как сделать по красоте)
                    'Голосовой чат' - Здесь мы общаемся, делимся опытом, делаем проекты, и даже иногда проводим лекции:)
                    """;

		await context.RespondAsync(message);
	}
}