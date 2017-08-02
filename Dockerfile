FROM microsoft/aspnetcore

RUN apt-get update && \
    apt-get install -y git && \
    apt-get -y autoremove && \
    apt-get -y clean && \
    rm -rf /var/lib/apt/lists/* && \
    rm -rf /tmp/*

WORKDIR /app
COPY /out .
CMD ["dotnet", "ScheduleTool.Api.dll"]
