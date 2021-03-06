﻿using eForm.Messages;
using eFormSqlController;
using Rebus.Handlers;
using System;
using System.Threading.Tasks;
using eFormShared;
using eFormCommunicator;

namespace eFormCore.Handlers
{
    public class TranscribeAudioFileHandler : IHandleMessages<TranscribeAudioFile>
    {
        private readonly SqlController sqlController;
        private readonly Communicator communicator;
        private readonly Log log;
        private readonly Core core;
        Tools t = new Tools();

        public TranscribeAudioFileHandler(SqlController sqlController, Communicator communicator, Log log, Core core)
        {
            this.sqlController = sqlController;
            this.communicator = communicator;
            this.log = log;
            this.core = core;
        }

#pragma warning disable 1998
        public async Task Handle(TranscribeAudioFile message)
        {
            try
            {
                core.TranscribeUploadedData(message.uploadedDataId);
            }
            catch 
            {
            }
        }
    }
}
